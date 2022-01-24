using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public static int health;

    [SerializeField]
    public int minHealth;
    [SerializeField]
    private int maxHealth = 3;

    public event Action OnHealthZero = delegate { };

    public void RestHealth(int restHealthValue)
    {
        health -= restHealthValue;

        if (health <= 0)
        {
            OnHealthZero();
            health = 1;
        }
    }

    public void IncreaseHealth(int value)
    {
        health += value;
    }

    public int ReturnHealth()
    {
        return health;
    }
}