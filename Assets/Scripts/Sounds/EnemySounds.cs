using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField]
    private GameObject shotSound;

    private BulletSystem _bs;

    void Awake()
    {
        _bs = GetComponent<BulletSystem>();
    }

    private void OnEnable()
    {
        _bs.OnShot += ShotSound;
    }

    private void OnDisable()
    {
        _bs.OnShot -= ShotSound;

    }

    void ShotSound()
    {
        SoundEmition(shotSound, transform.position, 2f);
    }

    private void SoundEmition(GameObject sound, Vector2 position, float duration)
    {
        GameObject newSound = Instantiate(sound, position, Quaternion.identity);
        Destroy(newSound, duration);
    }
}
