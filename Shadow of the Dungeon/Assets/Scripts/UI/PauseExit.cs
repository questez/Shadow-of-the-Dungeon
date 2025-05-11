using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseExit : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    private string _sceneName;
    private void Awake()
    {
        _sceneName = gameObject.scene.name;
        _button.onClick.AddListener(Exit);
        if (_sceneName == "StartRoom")
        {
            _button.interactable = false;
        }
    }
    private void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}