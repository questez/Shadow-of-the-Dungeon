using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyStateManager : MonoBehaviour
{
    private Transform currentEnemyTarget;
    public Animator EnemyAnimator;
    [SerializeField] private GridLayoutGroup HeartRow;
    [SerializeField] private NavMeshAgent navMeshAgent;

    Collider[] allEnemyColliders;
    [SerializeField] private Collider _damageCollider1, _damageCollider2; // ссылки на коллайдеры для нанесения урона игроку

    [NonSerialized] public PlayerBehaviour pb;

    [SerializeField] GameObject coin;
    

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
        allEnemyColliders = GetComponentsInChildren<Collider>();
        pb = FindAnyObjectByType<PlayerBehaviour>();
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

    public void SetEnemyHearts()
    {
        int heartCount = (int)(EnemyHP / 20);
        Image[] hearts = HeartRow.GetComponentsInChildren<Image>();
        foreach (Image h in hearts)
        {
            h.gameObject.SetActive(false);
        }
        for (int i = 0; i < heartCount; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].fillAmount = 1f;
        }
        if (EnemyHP % 20 != 0)
        {
            if (EnemyHP % 20 < 11)
            {
                hearts[heartCount].fillAmount = 0.5f;
            }
            hearts[heartCount].gameObject.SetActive(true);
        }
        if (EnemyHP <= 0)
        {
            hearts[0].gameObject.SetActive(false);
        }
    }

    public void SetSpeed(float newSpeed) // контроль скорости врага
    {
        navMeshAgent.speed = newSpeed;
    }    

    public float DistanceToTarget // расчет дистанции до игрока
    {
        get { return (transform.position - currentEnemyTarget.position).magnitude; }       
    }

    private void Update()
    {
        //Debug.Log(DistanceToTarget);
        navMeshAgent.destination = currentEnemyTarget.position; // отслеживание позиции игрока
        currentState.UpdateState(this);        
    }

    public void SpawnOneCoin() // спавн 1 монеты после убийства пауков и скелетов
    {
        Instantiate(coin, new Vector3(transform.position.x, 1.3f, transform.position.z), transform.rotation);
    }
    
    public void SpawnFiveCoins() // спавн 5 монет после убийства минотавра
    {
        for (float i = 0.2f; i <= 1f; i += 0.2f)
        {
            Instantiate(coin, new Vector3(transform.position.x - 0.9f + i, 1.3f, transform.position.z), transform.rotation);
        }
    }
    public void SpawnTenCoins() // спавн 10 монет после убийства голема
    {
        for (float i = 0.2f; i <= 1f; i += 0.2f)
        {
            Instantiate(coin, new Vector3(transform.position.x - 0.9f + i, 1.3f, transform.position.z), transform.rotation);
            Instantiate(coin, new Vector3(transform.position.x - 0.9f + i, 1.3f, transform.position.z - 0.4f), transform.rotation);
        }        
    }
    public void SpawnTwentyCoins() // спавн 20 монет после убийства демона
    {
        for (float i = 0.2f; i <= 1f; i += 0.2f)
        {
            Instantiate(coin, new Vector3(transform.position.x - 0.9f + i, 1.3f, transform.position.z), transform.rotation);
            Instantiate(coin, new Vector3(transform.position.x - 0.9f + i, 1.3f, transform.position.z - 0.4f), transform.rotation);
            Instantiate(coin, new Vector3(transform.position.x - 0.9f + i, 1.3f, transform.position.z - 0.6f), transform.rotation);
            Instantiate(coin, new Vector3(transform.position.x - 0.9f + i, 1.3f, transform.position.z - 0.8f), transform.rotation);
        }
    }

    public void OnOffDamager(int switcher)
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

    public void OffAllColliders()
    {
        foreach (Collider c in allEnemyColliders)
        {
            c.enabled = false;
        }
    }

}
