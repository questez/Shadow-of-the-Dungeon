using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // нанесение урона от игрока врагу
    {
        if (other.gameObject.CompareTag("Weapon") && FindAnyObjectByType<GrabWeapon>().HitTrack)
        {
            Debug.Log($"Удар произведен по врагу! Ему нанесен урон, равный {other.gameObject.GetComponent<GrabWeapon>().PlayerDamage + PlayerBehaviour.ExtraDamage}");
            GetComponentInParent<EnemyStateManager>().EnemyHP -= (other.gameObject.GetComponent<GrabWeapon>().PlayerDamage + PlayerBehaviour.ExtraDamage);
        }
        if (other.gameObject.CompareTag("Fireball"))
        {
            Debug.Log($"Огненный шар попал по врагу! Ему нанесен урон, равный {PlayerBehaviour.FireballDamage + (PlayerBehaviour.ExtraDamage * 0.5f)}");
            GetComponentInParent<EnemyStateManager>().EnemyHP -= (PlayerBehaviour.FireballDamage + (PlayerBehaviour.ExtraDamage * 0.5f));
        }
        if (other.gameObject.CompareTag("HexFireball"))
        {
            Debug.Log($"Тёмный шар попал по врагу! Ему нанесен урон, равный {PlayerBehaviour.HexDamage + (PlayerBehaviour.ExtraDamage * 0.5f)}");
            GetComponentInParent<EnemyStateManager>().EnemyHP -= (PlayerBehaviour.HexDamage + (PlayerBehaviour.ExtraDamage * 0.5f));
        }
        GetComponentInParent<EnemyStateManager>().SetEnemyHearts();
    }
}
