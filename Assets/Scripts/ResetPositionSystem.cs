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

        transform.position = new Vector3(DBManager.posX * 0.001f, DBManager.posY * 0.001f, 0);
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
