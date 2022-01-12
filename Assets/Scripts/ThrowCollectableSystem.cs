using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThrowCollectableSystem : MonoBehaviour
{
    private HealthSystem _healthSystem;

    [SerializeField]
    private Transform collectablePoint;

    private int healthValue;
    [SerializeField]
    private int minValue;
    [SerializeField]
    private int maxValue;

    private GameObject collectable;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }
    private void OnEnable()
    {
        _healthSystem.OnHealthZero += ThrowCollectable;
    }

    private void OnDisable()
    {
        _healthSystem.OnHealthZero -= ThrowCollectable;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void ThrowCollectable()
    {
        healthValue = _healthSystem.ReturnHealth();

        if (healthValue < 3)
        {
            minValue = 0;
        }
        else
        {
            minValue = 1;
        }

        int random = UnityEngine.Random.Range(minValue, maxValue);//0:Heart/1:Blaster/2:Laser

        Debug.Log(random);

        if (random == 0)
        {
            collectable = PoolingManager.Instance.GetPooledObject("collectableHeartList");

            collectable.SetActive(true);
        }
        else if (random == 1)
        {
            collectable = PoolingManager.Instance.GetPooledObject("collectableBlasterList");

            collectable.SetActive(true);
        }
        else
        {
            collectable = PoolingManager.Instance.GetPooledObject("collectableLaserList");

            collectable.SetActive(true);
        }

        collectable.transform.position = collectablePoint.position;
    }
}
