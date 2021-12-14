using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private int maxHealth = 10;

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

    public int ReturnHealth()
    {
        return health;
    }
}