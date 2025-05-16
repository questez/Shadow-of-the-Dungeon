using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy; 
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnTimeInterval = 5f;
    [SerializeField] int MaxNumberOfEnemies;
    float timer = 0f;

    private void Update()
    {
        TimerSpawn();
        Debug.Log($"Количество {enemy.name} равно {currentNumberOfEnemies}");
    }

    private void TimerSpawn()
    {

        timer += Time.deltaTime;

        if ((timer >= spawnTimeInterval) && (currentNumberOfEnemies < MaxNumberOfEnemies))
        {
            SpawnEnemy();
            timer = 0f;
        }     
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    private int currentNumberOfEnemies
    {
        get { return GameObject.FindGameObjectsWithTag(enemy.tag).Length; }
    }

}
