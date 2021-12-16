using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Actions/ShotLaser")]
public class ShotLaser : FSM.Action
{
    public override void Act(Controller controller)
    {
        controller.SetAnimation("idle", false);
        controller.SetAnimation("hurt", false);
        controller.SetAnimation("shootBlaster", false);
        controller.SetAnimation("shootLaser", true);
        controller.SetAnimation("run", false);
        controller.SetAnimation("jump", false);
    }
}
