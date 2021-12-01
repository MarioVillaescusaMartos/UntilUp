using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterSystem : ShootingSystem
{
    /*private void Shoot()
    {
        /*if (shootType == false)
        {
            for (int i = 1; i < 3; i++)
            {
                var shot = Instantiate(projectile, shotPoint[i].position, shotPoint[i].rotation);
                shot.GetComponent<Rigidbody2D>().AddForce(shotPoint[i].up * fireForce);
            }
            var telShoot = Mathf.Atan2(meteorite.y - projectile.y, meteorite.x - projectile.x);
        } 
    }*/

    void Awake()
    {
        InputSystemKeyboard sk;

        if (TryGetComponent<InputSystemKeyboard>(out sk))
        {
            sk.OnFire += Shoot;
        }
    }

    void Start()
    {
    }
    public override void Shoot()
    {
        /*var shoot = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        shoot.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.up * fireForce);*/

        GameObject shot = PoolingManager.Instance.GetPooledObject("blasterList");
        if (shot != null && bullets > 0)
        {
            shot.transform.position = shotPoint.position;
            shot.transform.rotation = shotPoint.rotation;
            shot.SetActive(true);
            shot.GetComponent<Rigidbody2D>().AddForce(transform.right * shootingdata.fireForce);
        }
    }
}