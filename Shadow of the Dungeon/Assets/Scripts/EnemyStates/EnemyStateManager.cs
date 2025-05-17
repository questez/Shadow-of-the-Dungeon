using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    private Transform currentEnemyTarget;
    public Animator EnemyAnimator;
    [NonSerialized] public PlayerBehaviour pb;
    [SerializeField] public TMPro.TMP_Text experienceText;
    [SerializeField] private NavMeshAgent navMeshAgent;     
    [SerializeField] private Collider _damageCollider1, _damageCollider2; // ссылки на коллайдеры для нанесения урона игроку

    public float ChaseDistance; // дистанция преследования игрока
    public float AttackDistance; // дистанция атаки на игрока

    public float EnemyHP, Enemyspeed, EnemyDamage;

    private BaseState currentState;
    [NonSerialized] public ChaseState chasestate = new ChaseState(); // [NonSerialized] public поле не высвечивается в Inspector
    [NonSerialized] public IdleState idlestate = new IdleState();
    [NonSerialized] public AttackState attackstate = new AttackState();   
    [NonSerialized] public DeathState deathstate = new DeathState();    
    
    private void Start()
    {
        pb = FindAnyObjectByType<XROrigin>().GetComponentInParent<PlayerBehaviour>();
        currentEnemyTarget = FindAnyObjectByType<XROrigin>().transform;
        if (_damageCollider1 != null) { _damageCollider1.enabled = false; } // при начале работы по умолчанию коллайдеры отключены
        if (_damageCollider2 != null) { _damageCollider2.enabled = false; }
        SwitchState(idlestate);
    }

    public void SwitchState(BaseState newState) // изменение состояния врага 
    {
        if (currentState != null)
        {
            currentState.ExitState(this);
        }       
        currentState = newState;   
        currentState.EnterState(this);
    }

    private void Update()
    {
        //Debug.Log(DistanceToTarget);
        navMeshAgent.destination = currentEnemyTarget.position; // отслеживание позиции игрока
        currentState.UpdateState(this);        
    }

    public void SetSpeed(float newSpeed) // контроль скорости врага
    {
        navMeshAgent.speed = newSpeed;
    }    

    public float DistanceToTarget // расчет дистанции до игрока
    {
        get { return (transform.position - currentEnemyTarget.position).magnitude; }       
    }


    // проверка, что враг проигрывает анимацию атаки до конца и только потом преследует игрока:
    private void CheckAttackTransition() // не работает почему-то
    {
        Debug.Log($"Distance: {DistanceToTarget}, AttackDist: {AttackDistance}, State: {currentState}");
        if (DistanceToTarget > AttackDistance)
        {
            if (currentState == attackstate)
            {
                SwitchState(chasestate);
                Debug.Log("EVENT is working");
            }
        }
        else Debug.Log("EVENT is NOT working");
    }
    
    private void OnOffDamager(int switcher)
    {
        if (switcher == 1)
        {
            if (_damageCollider1 != null) { _damageCollider1.enabled = true; }
            if (_damageCollider2 != null) { _damageCollider2.enabled = true; }
        }
        else
        {
            if (_damageCollider1 != null) { _damageCollider1.enabled = false; }
            if (_damageCollider2 != null) { _damageCollider2.enabled = false; }
        }
    }
    
    

}
