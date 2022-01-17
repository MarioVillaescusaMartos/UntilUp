using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

abstract class ScoreIncrement : MonoBehaviour
{
    [SerializeField]
    public static int incrementValue;

    private ScoreSystem _ss;    

    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void OnEnable()
    {
        _healthSystem.OnHealthZero += PassIncrementValue;
    }

    private void OnDisable()
    {
        _healthSystem.OnHealthZero -= PassIncrementValue;
    }

    // Update is called once per frame
    public static void PassIncrementValue()
    {
        if (TryGetComponent<ScoreSystem>(out _ss))
        {
            _ss.IncrementScore(incrementValue);
            
        }
        //Debug.Log(incrementValue);
    }
}
