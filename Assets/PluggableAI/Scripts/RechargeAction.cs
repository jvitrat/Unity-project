using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Recharge")]
public class RechargeAction : Action
{
    public override void Act(StateController controller)
    {
        Recharge (controller);
    }

    private void Recharge(StateController controller)
    {
        controller.navMeshAgent.destination = controller.RechargePointList [controller.closestRechargePoint].position;
        controller.navMeshAgent.Resume ();

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
        {controller.tankHealth.m_CurrentHealth=100f;
   	 controller.tankHealth.SetHealthUI ();
        }
    }
}

