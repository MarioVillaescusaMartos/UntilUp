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
    [SerializeField]
    private GameObject blasterRechargeSound;
    [SerializeField]
    private GameObject laserrRechargeSound;
    [SerializeField]
    private GameObject heartRechargeSound;

    private BlasterSystem _bs;
    private LaserSystem _ls;
    private Engine _engine;
    private TpSystem _tp;
    private PlayerHealthSystem _phs;

    void Awake()
    {
        _bs = GetComponent<BlasterSystem>();
        _ls = GetComponent<LaserSystem>();
        _engine = GetComponent<Engine>();
        _tp = GetComponent<TpSystem>();
        _phs = GetComponent<PlayerHealthSystem>();
    }

    private void OnEnable()
    {
        _bs.OnShot += BlasterSound;
        _ls.OnShot += LaserSound;
        _engine.OnJumped += JumpSound;
        _tp.OnTp += TpSound;
        _bs.OnBulletIncrease += BlasterRechargeSound;
        _ls.OnBulletIncrease += LaserRechargeSound;
        _phs.OnHealthIncrease += HealthRechargeSound;
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

    private void BlasterSound()
    {
        SoundEmition(blasterShotSound, transform.position, 2f);
    }

    private void LaserSound()
    {
        SoundEmition(laserShotSound, transform.position, 2f);
    }

    private void JumpSound()
    {
        SoundEmition(jumpSound, transform.position, 2f);
    }

    private void TpSound()
    {
        SoundEmition(tpSound, transform.position, 2f);
    }

    private void BlasterRechargeSound()
    {
        SoundEmition(blasterRechargeSound, transform.position, 2f);

    }

    private void LaserRechargeSound()
    {
        SoundEmition(laserrRechargeSound, transform.position, 2f);

    }

    private void HealthRechargeSound()
    {
        SoundEmition(heartRechargeSound, transform.position, 2f);

    }


    private void SoundEmition(GameObject sound, Vector2 position, float duration)
    {
        GameObject newSound = Instantiate(sound, position, Quaternion.identity);
        Destroy(newSound, duration);
    }
}
