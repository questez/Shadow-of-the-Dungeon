using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Destroy(this.gameObject);
        }
    }
}
