using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float PlayerHP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spider"))
        {
            Debug.Log($"Игроку нанесен урон от Spider {other.GetComponentInParent<EnemyStateManager>().EnemyDamage}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("Golem"))
        {
            Debug.Log($"Игроку нанесен урон от Golem {other.GetComponentInParent<EnemyStateManager>().EnemyDamage}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("Minotaur"))
        {
            Debug.Log($"Игроку нанесен урон от Minotaur {other.GetComponentInParent<EnemyStateManager>().EnemyDamage}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("Skeleton"))
        {
            Debug.Log($"Игроку нанесен урон от Skeleton {other.GetComponentInParent<EnemyStateManager>().EnemyDamage}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
    }

}
