using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : ShootingSystem
{
    private SpriteRenderer _sp;

    [SerializeField]
    private float waitTime;

    private bool waiting;
    private float saveWaitingTime;

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
        saveWaitingTime = waitTime;
    }

    private void Update()
    {
        if (waiting)
        {
            if (waitTime <= 0)
            {
                waiting = false;
                waitTime = saveWaitingTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    public override void Shoot()
    {
        
        /*var shoot = Instantiate(projectile, shotPoint.position, shotPoint.rotation);
        shoot.GetComponent<Rigidbody2D>().AddForce(shotPoint.transform.up * fireForce);*/

        GameObject shot = PoolingManager.Instance.GetPooledObject("bulletList");
        if (shot != null && !waiting)
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

            waiting = true;
        }
    }
}
