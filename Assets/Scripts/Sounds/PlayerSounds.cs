using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private GameObject blasterShotSound;
    [SerializeField]
    private GameObject laserShotSound;
    [SerializeField]
    private GameObject jumpSound;
    [SerializeField]
    private GameObject tpSound;

    private BlasterSystem _bs;
    private LaserSystem _ls;
    private Engine _engine;
    private TpSystem _tp;

    void Awake()
    {
        _bs = GetComponent<BlasterSystem>();
        _ls = GetComponent<LaserSystem>();
        _engine = GetComponent<Engine>();
        _tp = GetComponent<TpSystem>();
    }

    private void OnEnable()
    {
        _bs.OnShot += BlasterSound;
        _ls.OnShot += LaserSound;
        _engine.OnJumped += JumpSound;
        _tp.OnTp += TpSound;
    }

    private void OnDisable()
    {
        _bs.OnShot -= BlasterSound;
        _ls.OnShot -= LaserSound;
        _engine.OnJumped -= JumpSound;
        _tp.OnTp -= TpSound;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void BlasterSound()
    {
        SoundEmition(blasterShotSound, transform.position, 2f);
    }

    void LaserSound()
    {
        SoundEmition(laserShotSound, transform.position, 2f);
    }

    void JumpSound()
    {
        SoundEmition(jumpSound, transform.position, 2f);
    }

    void TpSound()
    {
        SoundEmition(tpSound, transform.position, 2f);
    }


    private void SoundEmition(GameObject sound, Vector2 position, float duration)
    {
        GameObject newSound = Instantiate(sound, position, Quaternion.identity);
        Destroy(newSound, duration);
    }
}
