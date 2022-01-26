using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlasterSystem : ShootingSystem
{
    private SpriteRenderer _sp;

    public event Action OnShot = delegate { };

    private int numBBullets;

    void Awake()
    {
        InputSystemKeyboard sk;

        _sp = GetComponent<SpriteRenderer>();

        if (TryGetComponent<InputSystemKeyboard>(out sk))
        {
            sk.OnFire1 += Shoot;
        }
    }

    void Start()
    {
        numBBullets = DBManager.blasterbullet;
    }
    public override void Shoot()
    {
        /*var shoot = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        shoot.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.up * fireForce);*/

        GameObject shot = PoolingManager.Instance.GetPooledObject("blasterList");
        if (shot != null && numBBullets > 0)
        {
            shot.SetActive(true);
            numBBullets -= 1;
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
            Debug.Log(numBBullets);

            OnShot();
        }
    }

    public override void IncreaseBullet(int value)
    {
        numBBullets += value;
    }

    public int ReturnBlasterBullet()
    {
        return numBBullets;
    }
}