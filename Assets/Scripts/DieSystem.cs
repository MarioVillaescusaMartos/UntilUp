using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DieSystem : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<HealthSystem>().OnHealthZero += Die;
    }

    private void OnDisable()
    {
        GetComponent<HealthSystem>().OnHealthZero -= Die;
    }

    public event Action OnDie = delegate { };

    private void Die()
    {
        OnDie();
        Destroy(gameObject);        
    }
}
