using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class CollectableSystem : MonoBehaviour
{
    public int increaseValue;

    public abstract void OnTriggerEnter2D(Collider2D collision);
}