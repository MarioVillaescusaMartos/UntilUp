using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    /*[SerializeField]
    private Transform gameCamera;
    [SerializeField]
    private float amplitude;

    private Vector3 originalPos;
    private bool shaking;*/

    public static CameraShake Instance { get; private set; }

    private CinemachineVirtualCamera _cvc;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Awake()
    {
        Instance = this;

        _cvc = GetComponent<CinemachineVirtualCamera>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void GenerateCameraShake(float intensity, bool activeShake)
    {
        _cbmcp = _cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (!activeShake)
        {
            _cbmcp.m_AmplitudeGain = intensity;
        }
        else
        {
            _cbmcp.m_AmplitudeGain = 0f;
        }
    }
}
