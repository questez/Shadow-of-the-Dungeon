using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy; 
    [SerializeField] Transform spawnPoint;
    float spawnTimeInterval = 5f;
    [SerializeField] int MaxNumberOfEnemies;

    [SerializeField] int MaxNumberOfSpawnedEnemies;

    int spawnCounter = 0;

    float timer = 0f;

    private void Update()
    {
        TimerSpawn();
        //Debug.Log($"Количество {enemy.name} равно {currentNumberOfEnemies}");
    }

    private void TimerSpawn()
    {

        timer += Time.deltaTime;

        if ((timer >= spawnTimeInterval) && (currentNumberOfEnemies < MaxNumberOfEnemies) && !StopSpawn)
        {
            SpawnEnemy();
            timer = 0f;
        }     
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        spawnCounter++;
    }

    private int currentNumberOfEnemies
    {
        get { return GameObject.FindGameObjectsWithTag(enemy.tag).Length; }
    }

    private bool StopSpawn
    {
        get
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level 1":
                    if (spawnCounter == MaxNumberOfSpawnedEnemies)
                    {                        
                        return true;
                    }
                    break;
                case "Level 2":
                    if (spawnCounter == MaxNumberOfSpawnedEnemies)
                    {                        
                        return true;
                    }
                    break;
                case "Level 3":
                    if (spawnCounter == MaxNumberOfSpawnedEnemies)
                    {                        
                        return true;
                    }
                    break;
                case "Level 4":
                    if (spawnCounter == MaxNumberOfSpawnedEnemies)
                    {                        
                        return true;
                    }
                    break;
            }
            return false;
        }
    }




}
