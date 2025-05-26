using UnityEngine;

public class HitEnemy : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other) // нанесение урона от игрока врагу
    {
        if (other.gameObject.CompareTag("Weapon") && FindAnyObjectByType<GrabWeapon>().HitTrack)
        {
            Debug.Log($"Удар произведен по врагу! Ему нанесен урон, равный {other.gameObject.GetComponent<GrabWeapon>().PlayerDamage}");
            GetComponentInParent<EnemyStateManager>().EnemyHP -= other.gameObject.GetComponent<GrabWeapon>().PlayerDamage;
        }
    }
}
