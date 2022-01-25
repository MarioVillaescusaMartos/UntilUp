using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterCollectableSystem : CollectableSystem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BlasterSystem bulletBlaster))
        {
            bulletBlaster.IncreaseBullet(increaseValue);
        }
        gameObject.SetActive(false);
    }
}
