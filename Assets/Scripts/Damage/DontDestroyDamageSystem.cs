using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyDamageSystem : DamageSystem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthSystem damageHealth))
        {
            damageHealth.RestHealth(restHealth);
        }
    }
}
