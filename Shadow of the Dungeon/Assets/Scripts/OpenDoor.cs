using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Collider doorTrigger;
    
    string name_scene;
    private void Awake()
    {
        name_scene = SceneManager.GetActiveScene().name;
    }
    private void Start()
    {                  
        if (doorTrigger != null && name_scene != "SaveZone")
        {
            doorTrigger.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            if (name_scene.StartsWith('L'))
            {                
                SceneManager.LoadScene("SaveZone");
                SavingSystem.SaveFinishedLevel(GameManager.lastLevelindex + 1);
            }     
            else if (name_scene == "StartRoom")
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (name_scene == "SaveZone" && (GameManager.lastLevelindex + 1) <= SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(GameManager.lastLevelindex + 1);
            }
        }        
    }
}
