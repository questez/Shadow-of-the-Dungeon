using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float PlayerHP;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpiderDamager"))
        {
            Debug.Log($"Игроку нанесен урон от Spider {other.GetComponentInParent<EnemyStateManager>().EnemyDamage}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("GolemDamager"))
        {
            Debug.Log($"Игроку нанесен урон от Golem {other.GetComponentInParent<EnemyStateManager>().EnemyDamage}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("MinotaurDamager"))
        {
            Debug.Log($"Игроку нанесен урон от Minotaur {other.GetComponentInParent<EnemyStateManager>().EnemyDamage}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("SkeletonDamager"))
        {
            Debug.Log($"Игроку нанесен урон от Skeleton {other.GetComponentInParent<EnemyStateManager>().EnemyDamage}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("DemonDamager"))
        {
            Debug.Log($"Игроку нанесен урон от Demon {other.GetComponentInParent<EnemyStateManager>().EnemyDamage}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
    }



}
