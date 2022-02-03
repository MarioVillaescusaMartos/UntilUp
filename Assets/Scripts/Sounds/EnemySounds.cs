using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField]
    private GameObject shotSound;
    [SerializeField]
    private GameObject deathSound;

    private BulletSystem _bs;
    private EnemyHealthSystem _ehs;

    void Awake()
    {
        _bs = GetComponent<BulletSystem>();
        _ehs = GetComponent<EnemyHealthSystem>();
    }

    private void OnEnable()
    {
        _bs.OnShot += ShotSound;
        _ehs.OnHealthZero += DeathSound;
    }

    private void OnDisable()
    {
        _bs.OnShot -= ShotSound;
        _ehs.OnHealthZero -= DeathSound;

    }

    void ShotSound()
    {
        SoundEmition(shotSound, transform.position, 2f);
    }

    void DeathSound()
    {
        SoundEmition(deathSound, transform.position, 1.5f);
    }

    private void SoundEmition(GameObject sound, Vector2 position, float duration)
    {
        GameObject newSound = Instantiate(sound, position, Quaternion.identity);
        Destroy(newSound, duration);
    }
}
