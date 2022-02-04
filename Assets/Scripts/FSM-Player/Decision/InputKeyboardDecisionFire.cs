using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Decision/Player/InputKeyboardDecisionFire")]
public class InputKeyboardDecisionFire : FSM.Decision
{
    private bool t;
    public override bool Decide(Controller controller)
    {
        if (!PauseManager.pauseMode)
        {
            t = (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"));
        }

        return t;
    }
}
