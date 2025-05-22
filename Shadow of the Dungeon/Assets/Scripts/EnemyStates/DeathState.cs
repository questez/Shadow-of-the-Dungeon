using UnityEngine;

public class DeathState : BaseState
{    
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("¬ход в deathstate");
        if (manager.CompareTag("Minotaur") || manager.CompareTag("Golem"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isMiniBossDefeated = true;
            manager.pb.PlayerXP += 10;
            manager.pb.PlayerXPInLevel += 10;
            manager.pb.ExperienceValue.text = manager.pb.PlayerXP.ToString();
        }
        if (manager.CompareTag("Demon"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isFinalBossDefeated = true;
            manager.pb.PlayerXP += 100;
            manager.pb.PlayerXPInLevel += 100;
            manager.pb.ExperienceValue.text = manager.pb.PlayerXP.ToString();
        }
        if (manager.CompareTag("Skeleton") || manager.CompareTag("Spider"))
        {            
            manager.pb.PlayerXP += 5;
            manager.pb.PlayerXPInLevel += 5;
            manager.pb.ExperienceValue.text = manager.pb.PlayerXP.ToString();
        }
        MonoBehaviour.FindAnyObjectByType<PlayerBehaviour>().KillCounter++;
        

        if (!manager.CompareTag("Demon"))
        { 
            manager.EnemyAnimator.SetTrigger("IsDeath");
        }
        MonoBehaviour.Destroy(manager.gameObject, 4f);        
    }

    public override void ExitState(EnemyStateManager manager) { }
    public override void UpdateState(EnemyStateManager manager) { }
}
