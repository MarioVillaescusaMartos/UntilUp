using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreIncrement : MonoBehaviour
{
    [SerializeField]
    public int incrementValue;

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
    public void PassIncrementValue()
    {
        if (TryGetComponent(out ScoreSystem _ss))
        {
            _ss.IncrementScore(incrementValue);
            
        }
        Debug.Log(incrementValue);
    }
}
