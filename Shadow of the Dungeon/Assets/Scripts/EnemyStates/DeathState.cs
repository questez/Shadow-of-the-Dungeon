using UnityEngine;

public class DeathState : BaseState
{    
    public override void EnterState(EnemyStateManager manager)
    {
        if (manager.CompareTag("Minotaur") || manager.CompareTag("Golem"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isMiniBossDefeated = true;
        }
        if (manager.CompareTag("Demon"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isFinalBossDefeated = true;
        }
        MonoBehaviour.FindAnyObjectByType<PlayerBehaviour>().KillCounter++;
        Debug.Log("¬ход в deathstate");

        if (!manager.CompareTag("Demon"))
        { 
            manager.EnemyAnimator.SetTrigger("IsDeath");
        }
        MonoBehaviour.Destroy(manager.gameObject, 4f);        
    }

    public override void ExitState(EnemyStateManager manager) { }
    public override void UpdateState(EnemyStateManager manager) { }
}
