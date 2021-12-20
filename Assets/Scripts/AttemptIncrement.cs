using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptIncrement : MonoBehaviour
{
    [SerializeField]
    private int increment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AttemptSystem attenptSystem))
        {
            //attenptSystem.IncrementAttempt(increment);
        }
    }
}
