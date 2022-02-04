using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Player/Actions/Idle")]
public class Idle : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", true);
        controller.SetAnimation("run", false);
        controller.SetAnimation("jump", false);
    }
}