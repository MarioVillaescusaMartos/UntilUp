using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    public int incrementValue;

    private ScoreSystem _ss;    

    private HealthSystem _healthSystem;

    public static int score;

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
        score = ScoreManager.score +  incrementValue;

        ScoreManager.score = score;

        Debug.Log("Score: " + score);
    }
}
