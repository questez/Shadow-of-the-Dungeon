using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    private PlayerBehaviour pb;
    private void Awake()
    {
        pb = FindAnyObjectByType<PlayerBehaviour>();
    }
    private void OnTriggerEnter(Collider other) // нанесение урона от игрока врагу
    {
        if (other.gameObject.CompareTag("Weapon") && FindAnyObjectByType<GrabWeapon>().rb.linearVelocity.magnitude > 1f)
        {
            Debug.Log($"Удар произведен по врагу! Ему нанесен урон, равный {other.gameObject.GetComponent<GrabWeapon>().PlayerDamage + pb.ExtraDamage}");
            GetComponentInParent<EnemyStateManager>().EnemyHP -= (other.gameObject.GetComponent<GrabWeapon>().PlayerDamage + pb.ExtraDamage);
        }
    }
}
