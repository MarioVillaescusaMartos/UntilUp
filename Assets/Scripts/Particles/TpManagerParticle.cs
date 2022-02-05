using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpManagerParticle : MonoBehaviour
{
    private ParticleSystem _ps;

    [SerializeField]
    private float stopTime;

    private bool waitingToEnd;
    private bool waitingToStart;
    // Start is called before the first frame update
    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TpParticleSystem.waitingToStart)
        {
            if (stopTime <= 0)
            {
                _ps.Stop();
            }
            else
            {
                stopTime -= Time.deltaTime;
            }
        }
    }
}
