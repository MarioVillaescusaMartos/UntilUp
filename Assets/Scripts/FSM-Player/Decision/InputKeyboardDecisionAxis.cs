using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Decision/Player/InputKeyboardDecisionAxis")]
public class InputKeyboardDecisionAxis : FSM.Decision
{
    public float hor { get; private set; } //get sirve para obtener/set para asignar

    //private InputSystemKeyboard _input;

    public override bool Decide(Controller controller)
    {
        if (!PauseManager.pauseMode)
        {
            hor = Input.GetAxis("Horizontal");
        }

        bool t = (hor < 0 || hor > 0);


        return t;
        
    }
}
