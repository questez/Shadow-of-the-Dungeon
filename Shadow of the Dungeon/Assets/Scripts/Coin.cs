using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float _rotationSpeed = 300f;
    [SerializeField] TMP_Text CoinValue;   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour pb = other.gameObject.GetComponent<PlayerBehaviour>();
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
