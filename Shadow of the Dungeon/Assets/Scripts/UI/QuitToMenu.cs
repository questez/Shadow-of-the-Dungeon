using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    private void Awake()
    {
        _button.onClick.AddListener(Quit);
    }
    private void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}