using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(this.gameObject);
        }
    }
}
