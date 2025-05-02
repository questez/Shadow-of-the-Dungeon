using UnityEngine;

public class DeathState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("¬ход в deathstate");
        manager.EnemyAnimator.SetTrigger("IsDeath");
        MonoBehaviour.Destroy(manager.gameObject, 3f);
    }

    public override void ExitState(EnemyStateManager manager)
    {
        
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        
    }
}
