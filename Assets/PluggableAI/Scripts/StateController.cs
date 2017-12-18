using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Complete;

public class StateController : MonoBehaviour {

    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    public State remainState;


    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Complete.TankShooting tankShooting;
    [HideInInspector] public Complete.TankHealth tankHealth;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public List<Transform> RechargePointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public int closestRechargePoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;


    void Awake () 
    {
        tankShooting = GetComponent<Complete.TankShooting> ();
	tankHealth = GetComponent<Complete.TankHealth> ();
        navMeshAgent = GetComponent<NavMeshAgent> ();
    }

    public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager,List<Transform> RechargePointsFromTankManager)
    {
        wayPointList = wayPointsFromTankManager;
	RechargePointList = RechargePointsFromTankManager;
        aiActive = aiActivationFromTankManager;
        if (aiActive) 
        {
            navMeshAgent.enabled = true;
        } else 
        {
            navMeshAgent.enabled = false;
        }
    }

    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null) 
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere (eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState) 
        {
            currentState = nextState;
            OnExitState ();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

}
