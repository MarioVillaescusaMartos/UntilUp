using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealthSystem : HealthSystem
{
    public event Action OnHealthZero = delegate { };

    public override void RestHealth(int restHealthValue)
    {
        health -= restHealthValue;

        if (health <= 0)
        {
            OnHealthZero();
            health = 1;
        }
    }
}
