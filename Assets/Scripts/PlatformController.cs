using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Engine speedEngine))
        {
            speedEngine.GetSpeed(speed);
        }
    }
}