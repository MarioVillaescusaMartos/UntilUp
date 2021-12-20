using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour
{    
    [SerializeField]
    private Transform[] positions;

    private EarthquakeManager _em;

    private bool reactivate;

    private void Awake()
    {
        _em = GetComponent<EarthquakeManager>();
    }

    private void OnEnable()
    {
        _em.OnTimerEnds += CallGenerateMeteor;
    }

    private void OnDisable()
    {
        _em.OnTimerEnds -= CallGenerateMeteor;

    }

    private void CallGenerateMeteor(bool activeMeteors)
    {
        if (!activeMeteors)
        {
            StartCoroutine(GenerateMeteor());
            
        }
        reactivate = activeMeteors;
    }

    IEnumerator GenerateMeteor()
    {
        
        int a = Random.Range(0, positions.Length);

        GameObject meteors = PoolingManager.Instance.GetPooledObject("meteorsList");
        meteors.transform.position = positions[a].position;
        meteors.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        if (!reactivate)
        {
            StartCoroutine(GenerateMeteor());
        }

        
    }
}
