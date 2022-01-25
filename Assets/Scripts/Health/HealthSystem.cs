using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    public static int health;

    public int minHealth;

    public int maxHealth;

    public abstract void RestHealth(int restHealthValue);
}