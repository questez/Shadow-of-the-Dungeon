using UnityEngine;

public class DeathState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("¬ход в deathstate");
    }

    public override void ExitState(EnemyStateManager manager)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        throw new System.NotImplementedException();
    }
}
