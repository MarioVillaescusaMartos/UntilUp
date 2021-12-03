using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Actions/Hurt")]
public class Hurt : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("hurt", true);
        controller.SetAnimation("shootBlaster", false);
        controller.SetAnimation("shootLaser", false);
        controller.SetAnimation("death", false);
        controller.SetAnimation("run", false);
        controller.SetAnimation("jump", false);
    }
}
