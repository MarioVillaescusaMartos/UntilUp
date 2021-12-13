using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField]
    private int restHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthSystem damageHealth))
        {
            damageHealth.RestHealth(restHealth);
        }

        gameObject.SetActive(false);
    }
}
