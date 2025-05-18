using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Collider doorTrigger;

    static int lastLevelindex;
    string name_scene;
    private void Awake()
    {
        name_scene = SceneManager.GetActiveScene().name;
    }
    private void Start()
    {
        if (name_scene.StartsWith('L'))
        {
            lastLevelindex = SceneManager.GetActiveScene().buildIndex;
        }          
        if (doorTrigger != null && SceneManager.GetActiveScene().name != "SaveZone")
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
            }     
            else if (name_scene == "StartRoom")
            {
                SceneManager.LoadScene("Level1");
            }
            else if (name_scene == "SaveZone" && (lastLevelindex + 1) <= SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(lastLevelindex + 1);
            }
        }        
    }
}
