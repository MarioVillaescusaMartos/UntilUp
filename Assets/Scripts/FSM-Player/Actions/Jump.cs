using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Actions/Jump")]
public class Jump : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("hurt", false);
        controller.SetAnimation("shootBlaster", false);
        controller.SetAnimation("shootLaser", false);
        controller.SetAnimation("death", false);
        controller.SetAnimation("run", false);
        controller.SetAnimation("jump", true);
    }
}
