using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MysteryBox"))
        {
            Debug.Log("Collision!");
            Destroy(this.gameObject);
        }
    }
}
