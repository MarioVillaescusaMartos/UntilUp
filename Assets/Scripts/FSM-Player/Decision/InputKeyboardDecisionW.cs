using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Decision/Player/InputKeyboardDecisionW")]
public class InputKeyboardDecisionW : FSM.Decision
{
    private InputSystemKeyboard _input;

    public override bool Decide(Controller controller)
    {
        bool t = _input.w;

        return t;
    }
}