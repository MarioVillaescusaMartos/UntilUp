using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealthSystem : HealthSystem
{
    public event Action OnHealthZero = delegate { };
    public event Action OnHealthIncrease = delegate { };
    public event Action OnHealthDecrease = delegate { };

    public bool INVENCIBLE;

    private void Awake()
    {
        health = DBManager.health;
    }

    void Start()
    {
        SendHealth();
    }

    public override void RestHealth(int restHealthValue)
    {
        if (!INVENCIBLE)
        {
            health -= restHealthValue;
            OnHealthDecrease();
        }

        if (health <= 0)
        {
            OnHealthZero();
            health = 1;
        }

        SendHealth();
    }

    public void IncreaseHealth(int value)
    {
        health += value;

        OnHealthIncrease();

        SendHealth();
    }

    public int ReturnHealth()
    {
        return health;
    }

    public void SendHealth()
    {
        HeartManager.heart = health;
        DBManager.health = health;
    }
}
