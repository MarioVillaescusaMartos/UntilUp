using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlasterCanvas : MonoBehaviour
{
    [SerializeField]
    private Text blasterDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blasterDisplay.text = ShotManager.blasterBullets.ToString();
    }
}
