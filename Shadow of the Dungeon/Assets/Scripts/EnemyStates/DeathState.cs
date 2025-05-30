using UnityEngine;

public class DeathState : BaseState
{    
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("¬ход в deathstate");
        manager.pb.KillCounter++;
        manager.pb.SetCurrentScore();     
        if (!manager.CompareTag("Demon"))
        { 
            manager.EnemyAnimator.SetTrigger("IsDeath");
        }
        MonoBehaviour.Destroy(manager.gameObject, 4f);        
    }

    public override void ExitState(EnemyStateManager manager) { }
    public override void UpdateState(EnemyStateManager manager) { }
}
