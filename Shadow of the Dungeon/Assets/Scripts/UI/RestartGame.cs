using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    public void Restart()
    {
        SceneManager.LoadScene("CommonEnemies");
    }
    private void Awake()
    {
        _button.onClick.AddListener(Restart);
    }
}
