using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Decision/Player/InputKeyboardDecision")]
public class InputKeyboardDecision : FSM.Decision
{
    public string keyName;
    public override bool Decide(Controller controller)
    {
        string k = controller.GetCurrentKey();

        bool t = (k == keyName);

        return t;
    }
}
