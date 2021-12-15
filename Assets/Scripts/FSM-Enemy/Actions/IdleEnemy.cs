using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Enemy/Actions/Idle")]
public class IdleEnemy : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", true);
        controller.SetAnimation("shot", false);
    }
}
