using UnityEngine;

public class AttackState : BaseState
{
    
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("Вход в attackstate");
        manager.SetSpeed(0);
    }

    public override void ExitState(EnemyStateManager manager)
    {
        Debug.Log("Выход из attackstate");
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.DistanceToTarget > 2)
        {
            manager.SwitchState(manager.chasestate);
        }        
        if (manager.EnemyHP <= 0)
        {
            manager.SwitchState(manager.deathstate);
            manager.gameObject.SetActive(false);
        }
    }    
}
