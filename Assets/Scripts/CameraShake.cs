using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private Transform gameCamera;
    [SerializeField]
    private float amplitude;

    private Vector3 originalPos;
    private bool shaking;

    private EarthquakeManager _em;

    private void Awake()
    {
        _em = GetComponent<EarthquakeManager>();
    }

    private void OnEnable()
    {
        _em.OnTimerEnds += CallGenerateCameraShake;
    }

    private void OnDisable()
    {
        _em.OnTimerEnds -= CallGenerateCameraShake;

    }
    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameCamera.localPosition;
    }

    // Update is called once per frame
    void CallGenerateCameraShake(bool activeShake)
    {
        if (!activeShake)
        {
            //originalPos = gameCamera.localPosition;
            StartCoroutine(GenerateCameraShake());
        }
        else
        {
            gameCamera.position = originalPos;
        }

        shaking = activeShake;
    }
    IEnumerator GenerateCameraShake()
    {
        float x = UnityEngine.Random.Range(-amplitude / 2, amplitude / 2);
        float y = UnityEngine.Random.Range(-amplitude / 2, amplitude / 2);
        Vector3 cameraNewPosition = new Vector3(x, y, -10);

        gameCamera.position = originalPos + cameraNewPosition;

        yield return new WaitForSeconds(0.1f);

        if (!shaking)
        {
            StartCoroutine(GenerateCameraShake());
        }
        
    }
}
