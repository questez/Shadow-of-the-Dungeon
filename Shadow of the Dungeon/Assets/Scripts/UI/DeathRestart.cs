using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRestart : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    
    private void Awake()
    {
        
        _button.onClick.AddListener(Restart);
        
    }    
    private void Restart()
    {
        SceneManager.LoadScene(OpenDoor.lastLevelindex);
    }
}
