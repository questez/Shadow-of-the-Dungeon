using UnityEngine;

public class AttackState : BaseState
{
    string golemAttack, spiderAttack, skeletonAttack, minotaurAttack, demonAttack; 
    public override void EnterState(EnemyStateManager manager)
    {        
        Debug.Log("Вход в attackstate");
        manager.SetSpeed(0);
        if (manager.CompareTag("Spider"))
        {
            spiderAttack = "IsAttack";
            manager.EnemyAnimator.SetBool(spiderAttack, true);
        } 
        if (manager.CompareTag("Golem"))
        {
            golemAttack = GolemCurrentAttack;
            manager.EnemyAnimator.SetBool(golemAttack, true);
        } 
        if (manager.CompareTag("Minotaur"))
        {
            minotaurAttack = MinotaurCurrentAttack;
            manager.EnemyAnimator.SetBool(minotaurAttack, true);
        }
        if (manager.CompareTag("Skeleton"))
        {
            skeletonAttack = "IsAttack";
            manager.EnemyAnimator.SetBool(skeletonAttack, true);
        }
        if (manager.CompareTag("Demon"))
        {
            demonAttack = "IsAttack";
            manager.EnemyAnimator.SetBool(demonAttack, true);
        }
    }

    public override void ExitState(EnemyStateManager manager)
    {
        Debug.Log("Выход из attackstate");
        if (manager.CompareTag("Golem")) manager.EnemyAnimator.SetBool(golemAttack, false);
        if (manager.CompareTag("Spider")) manager.EnemyAnimator.SetBool(spiderAttack, false);
        if (manager.CompareTag("Minotaur")) manager.EnemyAnimator.SetBool(minotaurAttack, false);
        if (manager.CompareTag("Skeleton")) manager.EnemyAnimator.SetBool(skeletonAttack, false);
        if (manager.CompareTag("Demon")) manager.EnemyAnimator.SetBool(demonAttack, false);
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        if (manager.DistanceToTarget > manager.AttackDistance)
        {
            manager.SwitchState(manager.idlestate);            
        }
        if (manager.EnemyHP <= 0)
        {
            manager.SwitchState(manager.deathstate);
            manager.pb.PlayerXP += 5;
            manager.pb.ExperienceValue.text = manager.pb.PlayerXP.ToString();
        }
    }   
    
    // Свойства (prop) анимаций атак для врагов, имеющих несколько вариантов воспроизведения:

    // "Minotaur":
    private string MinotaurCurrentAttack
    {
        get
        {
            string[] attack_list = { "IsAttack1", "IsAttack2", "IsAttack3" };
            System.Random rand = new System.Random();
            return attack_list[rand.Next(0, 3)];
        }
    }

    // "Golem":
    private string GolemCurrentAttack
    {
        get
        {
            string[] attack_list = { "IsAttack1", "IsAttack2" };
            System.Random rand = new System.Random();
            return attack_list[rand.Next(0, 2)];
        }
    }
    
}
