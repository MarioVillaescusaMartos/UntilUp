using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSounds : MonoBehaviour
{
    [SerializeField]
    private GameObject earthquaketSound;

    private EarthquakeManager _em;

    private void Awake()
    {
        _em = GetComponent<EarthquakeManager>();
    }

    private void OnEnable()
    {
        _em.OnTimerEnds += EarthquakeSound;
    }

    private void OnDisable()
    {
        _em.OnTimerEnds -= EarthquakeSound;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EarthquakeSound(bool play)
    {
        if (!play)
        {
            SoundEmition(earthquaketSound, transform.position, 30f);
        }
    }

    private void SoundEmition(GameObject sound, Vector2 position, float duration)
    {
        GameObject newSound = Instantiate(sound, position, Quaternion.identity);
        Destroy(newSound, duration);
    }
}
