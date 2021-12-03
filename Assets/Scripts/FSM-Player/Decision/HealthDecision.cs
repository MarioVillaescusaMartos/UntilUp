using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Player/Decision/HealthDecision")]
public class HealthDecision : FSM.Decision
{
    public int health;
    public int maxHealth;
    public override bool Decide(Controller controller)
    {
        int h = controller.GetCurrentHealth();
        bool t = (h == health || h < maxHealth);

        maxHealth = h;

        return t;
    }

}
