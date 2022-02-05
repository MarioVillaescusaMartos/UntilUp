using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TpParticle : MonoBehaviour
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
        GetComponent<TpSystem>().OnTp += Tp;
    }

    private void OnDisable()
    {
        GetComponent<TpSystem>().OnTp -= Tp;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Tp()
    {
        tp.transform.position = tpPoint.transform.position;
        waitingToStart = true;
        tp.Play();
    }
}
