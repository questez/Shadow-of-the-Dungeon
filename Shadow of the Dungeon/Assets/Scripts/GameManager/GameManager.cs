using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lastLevelindex = 0;

    [NonSerialized] public bool isMiniBossDefeated = false;
    [NonSerialized] public bool isFinalBossDefeated = false;
    bool isBoxSpawned = false, isWorkingMessage = false;
    
    LevelEndMessage levelEndMessage;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name.StartsWith('L'))
        {
            lastLevelindex = SceneManager.GetActiveScene().buildIndex;
        }
        levelEndMessage = GetComponent<LevelEndMessage>();        
    }

    private void Update()
    {
        FinishLevel();
        if (isWorkingMessage)
        {
            levelEndMessage.collected_coins.text = levelEndMessage.pb.PlayerBalanceInLevel.ToString();
        }
    }    

    private void FinishLevel()
    {
        string name_scene = SceneManager.GetActiveScene().name;
        if (name_scene.StartsWith('L'))
        {
            if ((isFinalBossDefeated || isMiniBossDefeated) && !isBoxSpawned)
            {
                isWorkingMessage = true;
                levelEndMessage.ShowMessage();
                GameObject musicSource = GameObject.FindGameObjectWithTag("MusicSource");
                musicSource.SetActive(false);
                GameObject.FindGameObjectWithTag("Door").GetComponent<OpenDoor>().doorTrigger.enabled = true;
                FindAnyObjectByType<BoxSpawner>().SpawnBox();
                isBoxSpawned = true;
            }          
        }        
    }    
}
