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
        if (stopTime <= 0)
        {
            stopTime -= Time.deltaTime;

            explosion.Stop();
        }
    }

    private void Explode()
    {
        explosion.transform.position = explosionPoint.transform.position;
        explosion.Play();
        Debug.Log("EXPLODE");
        stopTime = 1f;
    }
}