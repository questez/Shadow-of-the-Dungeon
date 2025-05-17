using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [NonSerialized] public bool isMiniBossDefeated = false;
    [NonSerialized] public bool isFinalBossDefeated = false;
    bool isBoxSpawned = false;
    // можно сделать границу для врагов лучше, чтобы они не сталкивались со столбами, либо поиграться с компонентами
    private void Update()
    {
        FinishLevel();
    }

    private void FinishLevel()
    {
        string name_scene = SceneManager.GetActiveScene().name;
        if (name_scene.StartsWith('L'))
        {
            if ((isFinalBossDefeated || isMiniBossDefeated) && !isBoxSpawned)
            {
                GameObject.FindGameObjectWithTag("Door").GetComponent<OpenDoor>().doorTrigger.enabled = true;
                FindAnyObjectByType<BoxSpawner>().SpawnBox();
                isBoxSpawned = true;
            }          
        }
        
    }


    
}
