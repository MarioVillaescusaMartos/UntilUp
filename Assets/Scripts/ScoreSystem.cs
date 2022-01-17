using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class ScoreSystem : MonoBehaviour
{
    public static int score;

    // Update is called once per frame
    private void Update()
    {
        
    }

    public int ReturnScore()
    {
        return score;
    }
}
