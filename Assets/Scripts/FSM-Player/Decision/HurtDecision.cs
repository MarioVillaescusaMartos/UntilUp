using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decision/HurtDecision")]
public class HurtDecision : FSM.Decision
{
    public int maxHealth;
    public override bool Decide(Controller controller)
    {
        int h = controller.GetCurrentHealth();

        bool t = (h < maxHealth);

        return t;
    }
}
