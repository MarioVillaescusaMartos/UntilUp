using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResetPositionSystem : MonoBehaviour
{
    private PlayerHealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<PlayerHealthSystem>();
    }

    private void OnEnable()
    {
        _healthSystem.OnHealthZero += ResetPosition;
    }

    private void OnDisable()
    {
        _healthSystem.OnHealthZero -= ResetPosition;
    }

    private void ResetPosition()
    {
        transform.position = GameObject.Find("RespawnPoint").transform.position;
        StopAllCoroutines();
    }
}
