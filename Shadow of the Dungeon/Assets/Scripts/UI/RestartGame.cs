using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    private string _sceneName;
    private void Awake()
    {
        _sceneName = gameObject.scene.name;
        _button.onClick.AddListener(Restart);
        if (_sceneName == "StartRoom" || _sceneName == "SaveZone")
        {
            _button.interactable = false;
        }
    }
    private void Restart()
    {        
        SceneManager.LoadScene(_sceneName);
        Time.timeScale = 1f;
    }
}
