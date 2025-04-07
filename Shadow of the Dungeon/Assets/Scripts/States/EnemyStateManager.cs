using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    BaseState currentState;
    public AgroState agrostate = new AgroState();
    public IdleState idlestate = new IdleState();
    public AttackState attackstate = new AttackState();

    private void Start()
    {
        SwitchState(idlestate);  
    }

    public void SwitchState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }       
        currentState = newState;   
        currentState.EnterState();
    }

    private void Update()
    {
        currentState.UpdateState();
    }
}
