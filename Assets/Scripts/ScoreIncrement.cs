using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreIncrement : MonoBehaviour
{
    [SerializeField]
    public static int incrementValue;

    private ScoreSystem _ss;    

    private HealthSystem _healthSystem;

    private int score;

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
        score += incrementValue;
        Debug.Log(score);
        //Debug.Log(score);
    }
}
