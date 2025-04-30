using UnityEngine;
using System.Collections.Generic;
using System;
public class AttackState : BaseState
{
    
    public override void EnterState(EnemyStateManager manager)
    {        
        Debug.Log("Вход в attackstate");
        manager.SetSpeed(0);
        if (manager.CompareTag("Spider")) SpiderAttack(manager);        
        if (manager.CompareTag("Golem")) GolemAttack(manager);        
    }

    public override void ExitState(EnemyStateManager manager)
    {
        Debug.Log("Выход из attackstate");
        manager.EnemyAnimator.SetTrigger("Idle");
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        
        if (manager.DistanceToTarget > manager.AttackDistance)
        {
            manager.SwitchState(manager.chasestate);
           
        }        
        if (manager.EnemyHP <= 0)
        {
            manager.SwitchState(manager.deathstate);            
        }
    }   
    
    // Методы анимаций атак для различных типов врагов:

    // "Spider":
    private void SpiderAttack(EnemyStateManager manager)
    {
         string[] spider_attack_list = { "IsAttack1", "IsAttack2" };
         System.Random rand = new System.Random();
         manager.EnemyAnimator.SetTrigger(spider_attack_list[rand.Next(0, 2)]);
    }

    // "Golem":
    private void GolemAttack(EnemyStateManager manager)
    {
        string[] golem_attack_list = { "IsAttack1", "IsAttack2" };
        System.Random rand = new System.Random();
        manager.EnemyAnimator.SetTrigger(golem_attack_list[rand.Next(0, 2)]);
    }
}
