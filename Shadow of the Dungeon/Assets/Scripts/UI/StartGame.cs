using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    private void Awake()
    {
        _button.onClick.AddListener(StartNewGame);
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("StartRoom");
    }
}
