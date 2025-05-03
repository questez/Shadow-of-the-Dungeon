using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _rotationSpeed = 300;
    private int countOfCoins = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            countOfCoins++;
            Destroy(this.gameObject);
            Debug.Log($"Собрана монетка! Текущее количество: {countOfCoins}.");
        }
    }

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
