using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttemptSystem : MonoBehaviour
{
    public static int attempt;

    [SerializeField]
    private int increment;

    private PlayerHealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<PlayerHealthSystem>();

        attempt = DBManager.attempt;
        IncrementAttempt();
    }

    private void OnEnable()
    {
        _healthSystem.OnHealthZero += IncrementAttempt;
    }

    private void OnDisable()
    {
        _healthSystem.OnHealthZero -= IncrementAttempt;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void IncrementAttempt()
    {
        attempt += increment;

        AttemptManager.attempts = attempt;
        DBManager.attempt = attempt;

        Debug.Log(attempt);
    }

    public int ReturnAttempt()
    {
        return attempt;
    }
}
