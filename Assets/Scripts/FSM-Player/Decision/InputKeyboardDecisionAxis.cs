using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Decision/Player/InputKeyboardDecisionAxis")]
public class InputKeyboardDecisionAxis : FSM.Decision
{
    private InputSystemKeyboard _input;

    public override bool Decide(Controller controller)
    {
        bool t = (_input.hor < 0 || _input.hor > 0);

        return t;
    }
}
