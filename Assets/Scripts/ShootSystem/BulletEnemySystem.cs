using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemySystem : ShootingSystem
{
    private SpriteRenderer _sp;

    void Awake()
    {
        EnemyView ev;
        _sp = GetComponent<SpriteRenderer>();

        if (TryGetComponent<EnemyView>(out ev))
        {
            ev.OnView += Shoot;
        }
    }

    void Start()
    {
    }
    public override void Shoot()
    {
        /*var shoot = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        shoot.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.up * fireForce);*/

        GameObject shotEnemy = PoolingManager.Instance.GetPooledObject("bulletEnemyList");
        if (shotEnemy != null)
        {
            shotEnemy.SetActive(true);
            if (_sp.flipX == true)
            {
                shotEnemy.transform.position = shotPoint[1].position;
                shotEnemy.transform.rotation = shotPoint[1].rotation;
                shotEnemy.GetComponent<Rigidbody2D>().AddForce(-transform.right * shootingdata.fireForce);
            }
            if (_sp.flipX == false)
            {
                shotEnemy.transform.position = shotPoint[0].position;
                shotEnemy.transform.rotation = shotPoint[0].rotation;
                shotEnemy.GetComponent<Rigidbody2D>().AddForce(transform.right * shootingdata.fireForce);
            }
        }
    }
}