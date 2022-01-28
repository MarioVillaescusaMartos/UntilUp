using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private Transform explosionPoint;

    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private float stopTime;

    public static bool waitingToStart;

    private void OnEnable()
    {
        GetComponent<EnemyHealthSystem>().OnHealthZero += Explode;
    }

    private void OnDisable()
    {
        GetComponent<EnemyHealthSystem>().OnHealthZero -= Explode;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        /*if (waitingToStart)
        {
            if (stopTime <= 0)
            {
                waitingToEnd = true;
            }
            else
            {
                stopTime -= Time.deltaTime;
                Debug.Log("EXPLODE");

            }
        }

        if (waitingToEnd)
        {
            explosion.Stop();

            waitingToStart = false;
        }*/
    }

    private void Explode()
    {
        explosion.transform.position = explosionPoint.transform.position;
        waitingToStart = true;
        explosion.Play();
    }
}