using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBoundActivation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 normpos = Camera.main.WorldToViewportPoint(pos);
        if (normpos.x < 1 || normpos.y > -0.2)
        {
            gameObject.SetActive(true);
        }
    }
}
