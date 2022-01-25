using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttemptCanvas : MonoBehaviour
{
    [SerializeField]
    private Text attemptDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attemptDisplay.text = "Attempt: " + AttemptSystem.attempt.ToString();
    }
}
