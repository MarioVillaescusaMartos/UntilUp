using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    public int incrementValue;

    private ScoreSystem _ss;    

    private EnemyHealthSystem _healthSystem;

    public static int score;

    private void Awake()
    {
        _healthSystem = GetComponent<EnemyHealthSystem>();

        score = DBManager.score;
        PassValue();
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
        
        DBManager.score = score;

        Debug.Log("Score: " + score);
        PassValue();
    }

    public void PassValue()
    {
        ScoreManager.score = score;
    }
}
