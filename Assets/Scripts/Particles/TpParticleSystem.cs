using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TpParticleSystem : MonoBehaviour
{
    [SerializeField]
    private Transform tpPoint;

    [SerializeField]
    private ParticleSystem tp;

    [SerializeField]
    private float stopTime;

    public static bool waitingToStart;

    private void OnEnable()
    {
        GetComponent<TpSystem>().OnTp += ActiveTp;
    }

    private void OnDisable()
    {
        GetComponent<TpSystem>().OnTp -= ActiveTp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void ActiveTp()
    {
        tp.transform.position = tpPoint.transform.position;
        waitingToStart = true;
        tp.Play();
    }
}
