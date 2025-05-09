using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _rotationSpeed = 300;
    [SerializeField] TMP_Text CoinValue;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour pb = collision.gameObject.GetComponent<PlayerBehaviour>();
            pb.PlayerBalance++;
            Destroy(this.gameObject);
            Debug.Log($"Собрана монетка! Текущее количество: {pb.PlayerBalance}.");
            CoinValue.text = pb.PlayerBalance.ToString();
        }
    }

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
