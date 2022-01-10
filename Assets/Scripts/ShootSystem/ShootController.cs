using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public ShootingSystemData[] shootingData;
    //public Transform[] shotPoints;
    private ShootingSystem launcher;

    private bool type;

    void Awake()
    {
        InputSystemKeyboard sk;

        if (TryGetComponent<InputSystemKeyboard>(out sk))
        {
            sk.OnFire += Shot;
        }
    }

    void Update()
    {
        var input = Input.inputString;
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (GetComponent<BlasterSystem>() == null)
            {
                Destroy(gameObject.GetComponent<LaserSystem>());
                BlasterSystem b = gameObject.AddComponent<BlasterSystem>();
                b.shootingdata = shootingData[0];
                //b.shotPoint = shotPoints[0];
                launcher = b;
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (GetComponent<LaserSystem>() == null)
            {
                Destroy(gameObject.GetComponent<BlasterSystem>());
                LaserSystem l = gameObject.AddComponent<LaserSystem>();
                l.shootingdata = shootingData[1];
                //l.shotPoint = shotPoints[0];
                launcher = l;
            }
        }
    }

    // Update is called once per frame
    void Shot()
    {
        launcher.Shoot();
    }
}