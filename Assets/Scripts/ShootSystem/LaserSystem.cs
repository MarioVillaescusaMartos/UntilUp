using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaserSystem : ShootingSystem
{
    private SpriteRenderer _sp;

    public event Action OnShot = delegate { };
    public event Action OnBulletIncrease = delegate { };

    private int numLBullets;

    void Awake()
    {
        InputSystemKeyboard sk;

        _sp = GetComponent<SpriteRenderer>();

        if (TryGetComponent<InputSystemKeyboard>(out sk))
        {
            sk.OnFire2 += Shoot;
        }
    }

    void Start()
    {
        numLBullets = DBManager.blasterbullet;
    }
    public override void Shoot()
    {
        /*var shoot = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        shoot.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.up * fireForce);*/

        GameObject shot = PoolingManager.Instance.GetPooledObject("laserList");
        if (shot != null && numLBullets > 0)
        {
            shot.SetActive(true);
            numLBullets -= 1;
            if (_sp.flipX == true)
            {
                shot.transform.position = shotPoint[1].position;
                shot.transform.rotation = shotPoint[1].rotation;
                shot.GetComponent<Rigidbody2D>().AddForce(-transform.right * shootingdata.fireForce);
            }
            if (_sp.flipX == false)
            {
                shot.transform.position = shotPoint[0].position;
                shot.transform.rotation = shotPoint[0].rotation;
                shot.GetComponent<Rigidbody2D>().AddForce(transform.right * shootingdata.fireForce);
            }
            SendNumBullets();

            OnShot();
        }
    }

    public override void IncreaseBullet(int value)
    {
        numLBullets += value;

        OnBulletIncrease();

        SendNumBullets();
    }

    public int ReturnLaserBullet()
    {
        return numLBullets;
    }

    private void SendNumBullets()
    {
        ShotManager.laserBullets = numLBullets;
    }
}
