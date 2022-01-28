using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectableSystem : CollectableSystem
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
        if (collision.TryGetComponent(out PlayerHealthSystem healthHeart))
        {
            healthHeart.IncreaseHealth(increaseValue);

        }
        gameObject.SetActive(false);
    }
}
