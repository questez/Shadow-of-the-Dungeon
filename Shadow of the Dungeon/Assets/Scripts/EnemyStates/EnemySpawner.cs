using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy; 
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnTimeInterval = 5f;
    float timer = 0f;
    // можно в принципе сделать триггерную зону
    private void Update()
    {
        TimerSpawn();
    }

    private void TimerSpawn()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTimeInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }

    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
