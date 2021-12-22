using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttemptManager
{
    public static int attempts;

    public static void GetAttempt()
    {
        attempts = AttemptSystem.attempt;
        //Debug.Log(attempts);
    }
}
