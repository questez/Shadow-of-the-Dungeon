using System.Linq;
using UnityEngine;

public class LightningDamage : MonoBehaviour
{
    private string[] enemyTags = { "Skeleton", "Spider", "Minotaur", "Golem", "Demon" };
    private void OnCollisionEnter(Collision collision)
    {
        if (enemyTags.Contains(collision.gameObject.tag))
        {
            Debug.Log($"Молния попала по врагу! Ему нанесен урон, равный {PlayerBehaviour.LightningDamage + (PlayerBehaviour.ExtraDamage * 0.5f)}");
            collision.gameObject.GetComponent<EnemyStateManager>().EnemyHP -= (PlayerBehaviour.LightningDamage + (PlayerBehaviour.ExtraDamage * 0.5f));
        }
        GetComponentInParent<EnemyStateManager>().SetEnemyHearts();
    }
}
