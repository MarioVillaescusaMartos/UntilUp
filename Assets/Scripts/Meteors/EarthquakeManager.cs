using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EarthquakeManager : MonoBehaviour
{
    [SerializeField]
    private float waitTimeStart;
    [SerializeField]
    public float waitTimeEnd;
    [SerializeField]
    public float intensity;

    public static float numWaitTimeEnd;
    public bool waitingToStart;
    public bool waitingToEnd;
    // Start is called before the first frame update
    void Start()
    {
        waitingToStart = true;
        waitingToEnd = false;

        SendCameraShake();
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

                SendCameraShake();
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
                numWaitTimeEnd = waitTimeEnd;

                OnTimerEnds(waitingToStart);

                SendCameraShake();
            }
            else
            {
                waitTimeEnd -= Time.deltaTime;
            }
        }
    }

    private void SendCameraShake()
    {
        CameraShake.Instance.GenerateCameraShake(intensity, waitingToStart);

    }
}
