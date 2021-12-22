using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static int score;

    // Update is called once per frame
    public void IncrementScore(int value)
    {
        score += value;
    }
}
