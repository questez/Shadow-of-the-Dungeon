using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform currentTarget;


    public float enemyHP;
    public float enemyspeed;

    private BaseState currentState;
    [NonSerialized] public ChaseState chasestate = new ChaseState(); // [NonSerialized] public поле не высвечивается в Inspector
    [NonSerialized] public IdleState idlestate = new IdleState();
    [NonSerialized] public AttackState attackstate = new AttackState();
    [NonSerialized] public DeathState deathstate = new DeathState();    
    
    private void Start()
    {
        SetDestination(currentTarget);
        SwitchState(idlestate);        
    }

    public void SwitchState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }       
        currentState = newState;   
        currentState.EnterState(this);
    }

    private void Update()
    {
        //Debug.Log(DistanceToTarget);
        navMeshAgent.destination = currentTarget.position;
        currentState.UpdateState(this);        
    }

    public void SetSpeed(float newSpeed)
    {
        navMeshAgent.speed = newSpeed;
    }

    public void SetDestination(Transform newDestination)
    {
        currentTarget = newDestination;
    }    

    public float DistanceToTarget
    {
        get { return (transform.position - currentTarget.position).magnitude; }       
    }
}
