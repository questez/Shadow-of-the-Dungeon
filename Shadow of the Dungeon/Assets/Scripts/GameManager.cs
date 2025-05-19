using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [NonSerialized] public bool isMiniBossDefeated = false;
    [NonSerialized] public bool isFinalBossDefeated = false;
    bool isBoxSpawned = false;
    [SerializeField] GameObject levelEndCanvas;

    private void Start()
    {
        levelEndCanvas = GameObject.Find("LevelEndCanvas");
        if (levelEndCanvas != null)
        {
            levelEndCanvas.SetActive(false);
        } 
    }

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
                levelEndCanvas.SetActive(true);
                GameObject musicSource = GameObject.FindGameObjectWithTag("MusicSource");
                musicSource.SetActive(false);
                GameObject.FindGameObjectWithTag("Door").GetComponent<OpenDoor>().doorTrigger.enabled = true;
                FindAnyObjectByType<BoxSpawner>().SpawnBox();
                isBoxSpawned = true;
            }          
        }        
    }    
}
