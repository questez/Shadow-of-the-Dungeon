using UnityEngine;

public class DeathState : BaseState
{    
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("¬ход в deathstate");
        if (manager.CompareTag("Minotaur"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isMiniBossDefeated = true;
            PlayerBehaviour.PlayerXP += 10;
            manager.pb.PlayerXPInLevel += 10;
        }
        if (manager.CompareTag("Golem"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isMiniBossDefeated = true;
            PlayerBehaviour.PlayerXP += 20;
            manager.pb.PlayerXPInLevel += 20;
        }
        if (manager.CompareTag("Demon"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isFinalBossDefeated = true;
            PlayerBehaviour.PlayerXP += 100;
            manager.pb.PlayerXPInLevel += 100;
        }
        if (manager.CompareTag("Skeleton") || manager.CompareTag("Spider"))
        {
            PlayerBehaviour.PlayerXP += 5;
            manager.pb.PlayerXPInLevel += 5;
        }



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
