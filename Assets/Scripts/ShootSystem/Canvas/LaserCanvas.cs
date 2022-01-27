using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserCanvas : MonoBehaviour
{
    [SerializeField]
    private Text laserDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laserDisplay.text = ShotManager.laserBullets.ToString();
    }
}
