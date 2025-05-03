using UnityEngine;

public class ChaseState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("Вход в chasestate");
        manager.SetSpeed(manager.Enemyspeed);
        manager.EnemyAnimator.SetBool("IsChase", true);
    }
    public override void ExitState(EnemyStateManager manager)
    {
        Debug.Log("Выход из chasestate");
        manager.EnemyAnimator.SetBool("IsChase", false);
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.DistanceToTarget > manager.ChaseDistance)
        {
            manager.SwitchState(manager.idlestate);
        }
        if (manager.DistanceToTarget < manager.AttackDistance)
        {
            manager.SwitchState(manager.attackstate);
        }
    }
}
