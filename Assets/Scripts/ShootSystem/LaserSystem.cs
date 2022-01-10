using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSystem : ShootingSystem
{
    private SpriteRenderer _sp;

    void Awake()
    {
        InputSystemKeyboard sk;

        _sp = GetComponent<SpriteRenderer>();

        /*if (TryGetComponent<InputSystemKeyboard>(out sk))
        {
            sk.OnFire += Shoot;
        }*/
    }

    void Start()
    {
    }
    public override void Shoot()
    {
        /*var shoot = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        shoot.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.up * fireForce);*/

        GameObject shot = PoolingManager.Instance.GetPooledObject("laserList");
        if (shot != null && bullets > 0)
        {
            shot.SetActive(true);
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
        }
    }

    public override void IncreaseBullet(int value)
    {
        bullets += value;
    }
}