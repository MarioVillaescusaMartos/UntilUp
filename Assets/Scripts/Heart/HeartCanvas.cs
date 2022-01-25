using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCanvas : MonoBehaviour
{
    [SerializeField]
    private Text heartDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heartDisplay.text = "Heart: " + HeartManager.heart.ToString();
    }
}
