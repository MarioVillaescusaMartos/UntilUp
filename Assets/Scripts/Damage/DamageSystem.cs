using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSystem : MonoBehaviour
{
    public int restHealth;

    public abstract void OnTriggerEnter2D(Collider2D collision);
}
