using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLaser : MonoBehaviour
{
    [SerializeField]
    private float timer;

    private float saveTimer;
    // Start is called before the first frame update
    void Start()
    {
        saveTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (timer <= 0)
            {
                gameObject.SetActive(false);
                timer = saveTimer;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        
    }
}
