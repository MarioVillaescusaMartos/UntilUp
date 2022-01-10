using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField]
    private Text scoreDisplay;

    private static ScoreSystem _ss;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + ScoreSystem.score;
    }
}