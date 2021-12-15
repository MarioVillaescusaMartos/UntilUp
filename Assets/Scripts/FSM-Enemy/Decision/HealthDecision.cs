using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Carnation/Decision/HealthDecision")]
public class HealthDecision : FSM.Decision
{
    public int healthLimitMin;
    public int healthLimitMax;
    public override bool Decide(Controller controller)
    {
        int h = controller.GetCurrentHealth();
        bool t = (h < healthLimitMax && h > healthLimitMin);

        return t;
    }
}
