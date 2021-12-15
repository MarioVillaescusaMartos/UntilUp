using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Decision/Enemy/HitDecision")]
public class HitDecision : FSM.Decision
{
    public override bool Decide(Controller controller)
    {
        bool h = controller.GetCurrentHit();

        return h;
    }
}
