using UnityEngine;

public class FinalBossSpawner : MonoBehaviour
{
    [SerializeField] GameObject FinalBoss;
    [SerializeField] Transform spawnPoint;
    bool isFinalBossSpawned = false;

    private void Update()
    {
        SpawnFinalBoss();
    }

    private void SpawnFinalBoss()
    {
        if (!isFinalBossSpawned)
        {
            Instantiate(FinalBoss, spawnPoint.position, spawnPoint.rotation);
            isFinalBossSpawned = true;
        }
    }
}
