using UnityEngine;

public class IdleState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        manager.SetSpeed(0);
        Debug.Log("Вход в idlestate");
    }
    public override void ExitState(EnemyStateManager manager)
    {
        Debug.Log("Выход из idlestate");
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.DistanceToTarget < manager.ChaseDistance)
        {
            manager.SwitchState(manager.chasestate);
        }
    }
}
