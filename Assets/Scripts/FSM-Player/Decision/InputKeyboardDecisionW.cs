using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Decision/Player/InputKeyboardDecisionW")]
public class InputKeyboardDecisionW : FSM.Decision
{
    //private InputSystemKeyboard _input;

    private bool t;

    public override bool Decide(Controller controller)
    {
        if (!PauseManager.pauseMode)
        {
            t = Input.GetKeyDown(KeyCode.W);
        }
        return t;
    }
}