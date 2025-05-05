using UnityEngine;

public class DeathState : BaseState
{
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("¬ход в deathstate");
        if (manager.CompareTag("Demon") == false) { manager.EnemyAnimator.SetTrigger("IsDeath"); }
        MonoBehaviour.Destroy(manager.gameObject, 4f);
    }

    public override void ExitState(EnemyStateManager manager) { }
    public override void UpdateState(EnemyStateManager manager) { }
}
