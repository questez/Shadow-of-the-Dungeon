using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [NonSerialized] public bool isMiniBossDefeated = false;
    bool isBoxSpawned = false;

    private void Update()
    {
        FinishLevel();
    }

    private void FinishLevel()
    {
        string name_scene = SceneManager.GetActiveScene().name;
        if (name_scene == "Level1" && isMiniBossDefeated && !isBoxSpawned)
        {
            GameObject.FindGameObjectWithTag("Door").GetComponent<OpenDoor>().doorTrigger.enabled = true;
            FindAnyObjectByType<BoxSpawner>().SpawnBox();
            isBoxSpawned = true;
        }        
    }


    
}
