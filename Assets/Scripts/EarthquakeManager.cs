using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EarthquakeManager : MonoBehaviour
{
    [SerializeField]
    private float waitTimeStart;
    [SerializeField]
    private float waitTimeEnd;

    public bool waitingToStart;
    public bool waitingToEnd;
    // Start is called before the first frame update
    void Start()
    {
        waitingToStart = true;
        waitingToEnd = false;
    }

    public event Action<bool> OnTimerEnds = delegate { };

    // Update is called once per frame
    void Update()
    {
        if (waitingToStart)
        {
            if (waitTimeStart <= 0)
            {
                waitingToStart = false;
                waitingToEnd = true;
                waitTimeStart = UnityEngine.Random.Range(30, 60);

                OnTimerEnds(waitingToStart);
            }
            else
            {
                waitTimeStart -= Time.deltaTime;
            }
        }
        else if (waitingToEnd)
        {
            if (waitTimeEnd <= 0)
            {
                waitingToStart = true;
                waitingToEnd = false;
                waitTimeEnd = UnityEngine.Random.Range(5, 30);

                OnTimerEnds(waitingToStart);
            }
            else
            {
                waitTimeEnd -= Time.deltaTime;
            }
        }
    }
}
