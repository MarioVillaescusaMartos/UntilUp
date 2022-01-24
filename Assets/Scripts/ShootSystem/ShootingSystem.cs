using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingSystem : MonoBehaviour
{
    public ShootingSystemData shootingdata;

    public Transform[] shotPoint;

    public static int bullets = 5;

    public abstract void Shoot();

    public abstract void IncreaseBullet(int value);
}