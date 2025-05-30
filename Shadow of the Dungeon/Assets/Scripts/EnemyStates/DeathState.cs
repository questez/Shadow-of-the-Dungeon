using UnityEngine;

public class DeathState : BaseState
{
    int enemyXP;
    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("¬ход в deathstate");
        if (manager.CompareTag("Minotaur"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isMiniBossDefeated = true;
            enemyXP = 10;
            manager.pb.ExperienceValue.text = PlayerBehaviour.PlayerXP.ToString();
        }
        if (manager.CompareTag("Golem"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isMiniBossDefeated = true;
            enemyXP = 20;
            manager.pb.ExperienceValue.text = PlayerBehaviour.PlayerXP.ToString();
        }
        if (manager.CompareTag("Demon"))
        {
            MonoBehaviour.FindAnyObjectByType<GameManager>().isFinalBossDefeated = true;
            enemyXP = 100;
            manager.pb.ExperienceValue.text = PlayerBehaviour.PlayerXP.ToString();
        }
        if (manager.CompareTag("Skeleton") || manager.CompareTag("Spider"))
        {
            enemyXP = 5;
            manager.pb.ExperienceValue.text = PlayerBehaviour.PlayerXP.ToString();
        }
        PlayerBehaviour.PlayerXP += enemyXP;
        manager.pb.PlayerXPInLevel += enemyXP;
        PlayerBehaviour.CheckPlayerLevel();

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