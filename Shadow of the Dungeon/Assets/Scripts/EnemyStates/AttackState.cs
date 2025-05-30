using UnityEngine;

public class AttackState : BaseState
{
    private string attack;
    public override void EnterState(EnemyStateManager manager)
    {        
        Debug.Log("Вход в attackstate");
        manager.SetSpeed(0);
        switch (manager.tag)
        {
            case "Skeleton":
                attack = "IsAttack";
                break;
            case "Spider":
                attack = "IsAttack";
                break;
            case "Minotaur":
                attack = MinotaurCurrentAttack;
                break;
            case "Golem":
                attack = GolemCurrentAttack;
                break;
            case "Demon":
                attack = "IsAttack";
                break;
        }
        manager.EnemyAnimator.SetBool(attack, true);
    }

    public override void ExitState(EnemyStateManager manager)
    {
        Debug.Log("Выход из attackstate");
        manager.EnemyAnimator.SetBool(attack, false);
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
            return attack_list[rand.Next(0, 1)];
        }
    }
    
}
