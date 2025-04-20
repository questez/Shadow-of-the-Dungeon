using UnityEngine;

public class ChaseState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("Вход в chasestate");
        manager.SetSpeed(manager.Enemyspeed);
    }
    public override void ExitState(EnemyStateManager manager)
    {
        Debug.Log("Выход из chasestate");
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.DistanceToTarget > 10)
        {
            manager.SwitchState(manager.idlestate);
        }
        if (manager.DistanceToTarget < 2)
        {
            manager.SwitchState(manager.attackstate);
        }
    }
}
