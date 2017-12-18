using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Recharge")]
public class RechargeDecision : Decision 
{
    public override bool Decide (StateController controller)
    {
        bool lowCharge = Recharge (controller);
        return lowCharge;
    }

    private bool Recharge(StateController controller)
    {
	if(controller.tankHealth.m_CurrentHealth<=30f)         
		return true;
	else
		return false;
     }
}
