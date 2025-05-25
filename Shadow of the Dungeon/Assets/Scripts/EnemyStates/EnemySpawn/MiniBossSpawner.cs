using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniBossSpawner: MonoBehaviour
{
    [SerializeField] GameObject miniBoss;
    [SerializeField] Transform spawnPoint;
    bool isMiniBossSpawned = false;
    
    private void Update()
    {
        SpawnMiniBoss();
    }

    private void SpawnMiniBoss()
    {
        if (EnemiesIsDefeated && !isMiniBossSpawned && currentNumberOfEnemies == 0)
        {
            Instantiate(miniBoss, spawnPoint.position, spawnPoint.rotation);
            isMiniBossSpawned = true;
        }
    }

    private bool EnemiesIsDefeated
    {
        get
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level 1":
                    if (FindAnyObjectByType<PlayerBehaviour>().KillCounter >= FindAnyObjectByType<PlayerBehaviour>().MaxKillsInLevel1)
                    {
                        EnemySpawner[] allNEnemySpawners = FindObjectsByType<EnemySpawner>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                        foreach (var spawner in allNEnemySpawners)
                        {
                            spawner.enabled = false;
                        }
                        return true;
                    }
                    break;
                case "Level 2":
                    if (FindAnyObjectByType<PlayerBehaviour>().KillCounter >= FindAnyObjectByType<PlayerBehaviour>().MaxKillsInLevel2)
                    {
                        EnemySpawner[] allNEnemySpawners = FindObjectsByType<EnemySpawner>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                        foreach (var spawner in allNEnemySpawners)
                        {
                            spawner.enabled = false;
                        }
                        return true;
                    }
                    break;
                case "Level 3":
                    if (FindAnyObjectByType<PlayerBehaviour>().KillCounter >= FindAnyObjectByType<PlayerBehaviour>().MaxKillsInLevel3)
                    {
                        EnemySpawner[] allNEnemySpawners = FindObjectsByType<EnemySpawner>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                        foreach (var spawner in allNEnemySpawners)
                        {
                            spawner.enabled = false;
                        }
                        return true;
                    }
                    break;
                case "Level 4":
                    if (FindAnyObjectByType<PlayerBehaviour>().KillCounter >= FindAnyObjectByType<PlayerBehaviour>().MaxKillsInLevel4)
                    {
                        EnemySpawner[] allNEnemySpawners = FindObjectsByType<EnemySpawner>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                        foreach (var spawner in allNEnemySpawners)
                        {
                            spawner.enabled = false;
                        }
                        return true;
                    }
                    break;
            }            
            return false;
        }
    }

    private int currentNumberOfEnemies
    {
        get { return GameObject.FindGameObjectsWithTag("Skeleton").Length + GameObject.FindGameObjectsWithTag("Spider").Length; }
    }
}
