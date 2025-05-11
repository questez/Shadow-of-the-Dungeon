using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Collider doorTrigger;

    private void Start()
    {
        if (doorTrigger != null)
        {
            doorTrigger.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            string name_scene = SceneManager.GetActiveScene().name;
            if (name_scene.StartsWith('L'))
            {
                int next = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(next);
            }     
            else if (name_scene == "StartRoom")
            {
                SceneManager.LoadScene("Level1");
            }
        }        
    }
}
