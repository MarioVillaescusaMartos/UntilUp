using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TpSystem : MonoBehaviour
{
    [SerializeField]
    private float time;
    private float waitTimer;

    [SerializeField]
    private Text textDysplay;

    private bool tpEnter;

    private Vector3 tpPosition;

    public event Action OnTp = delegate { };

    private void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnTp += Tp;
        GetComponent<PlayerHealthSystem>().OnHealthZero += ResetTp;
    }

    private void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnTp -= Tp;
        GetComponent<PlayerHealthSystem>().OnHealthZero -= ResetTp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (waitTimer <= 0)
        {
            tpPosition = transform.position;
            waitTimer = time;
            tpEnter = true;
        }
        else
        {
            waitTimer -= Time.deltaTime;
            textDysplay.text = "TP: not available";
        }

        if (tpEnter)
        {
            textDysplay.text = "TP: available";
        }
    }

    // Update is called once per frame
    private void Tp()
    {
        if (tpEnter)
        {
            transform.position = tpPosition;
            tpEnter = false;

            OnTp();
        }
    }

    private void ResetTp()
    {
        waitTimer = 0;
    }
}
