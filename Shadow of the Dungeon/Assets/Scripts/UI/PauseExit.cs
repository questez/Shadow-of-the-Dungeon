using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseExit : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    private void Awake()
    {
        _button.onClick.AddListener(Exit);
        if (gameObject.scene.name == "StartRoom")
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