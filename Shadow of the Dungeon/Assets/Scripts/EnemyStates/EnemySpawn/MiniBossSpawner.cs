using UnityEngine;

public class MiniBossSpawner : MonoBehaviour
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
            if (FindAnyObjectByType<PlayerBehaviour>().KillCounter > FindAnyObjectByType<PlayerBehaviour>().MaxKillsInLevel)
            {
                EnemySpawner[] allNEnemySpawners = FindObjectsByType<EnemySpawner>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                foreach (var spawner in allNEnemySpawners)
                {
                    spawner.enabled = false;
                }                
                return true;
            }
            return false;
        }
    }

    private int currentNumberOfEnemies
    {
        get { return GameObject.FindGameObjectsWithTag("Skeleton").Length + GameObject.FindGameObjectsWithTag("Spider").Length; }
    }
}
