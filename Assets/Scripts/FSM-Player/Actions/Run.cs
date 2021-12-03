using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Actions/Run")]
public class Run : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("hurt", false);
        controller.SetAnimation("shootBlaster", false);
        controller.SetAnimation("shootLaser", false);
        controller.SetAnimation("death", false);
        controller.SetAnimation("run", true);
        controller.SetAnimation("jump", false);
    }
}
