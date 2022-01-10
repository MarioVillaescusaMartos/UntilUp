using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollectableSystem : CollectableSystem
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
        if (collision.TryGetComponent(out LaserSystem bulletLaser))
        {
            bulletLaser.IncreaseBullet(increaseValue);
        }
        gameObject.SetActive(false);
    }
}
