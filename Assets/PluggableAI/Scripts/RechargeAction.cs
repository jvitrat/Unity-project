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
    { int c=0;

        controller.navMeshAgent.destination = controller.RechargePointList [controller.closestRechargePoint].position;
        controller.navMeshAgent.Resume ();

        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) 
        { 
		if(controller.activeRechargePoints[controller.closestRechargePoint])
		{	
			controller.tankHealth.m_CurrentHealth=100f;
  		 	controller.tankHealth.SetHealthUI ();
			controller.activeRechargePoints[controller.closestRechargePoint]=false;
		}
		else
		{ 
			while ((c<controller.activeRechargePoints.Count+2)&&(controller.activeRechargePoints[controller.closestRechargePoint]!=true))
				{
					controller.closestRechargePoint = (controller.closestRechargePoint + 1) % controller.wayPointList.Count;
					c++;
				}
			if(c<=controller.activeRechargePoints.Count)
			{
				controller.navMeshAgent.destination = controller.RechargePointList [controller.closestRechargePoint].position;
        			controller.navMeshAgent.Resume ();
			}
			else
			{
				controller.recoveryDisabled=true;
			}
	
		}
	}
   }
}

