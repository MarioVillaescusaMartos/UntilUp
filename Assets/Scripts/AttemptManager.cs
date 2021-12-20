using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttemptManager
{
    public static int attempt;

    public static void GetAttempt()
    {
        attempt = AttemptSystem.attempt;
        Debug.Log(attempt);
    }
}
