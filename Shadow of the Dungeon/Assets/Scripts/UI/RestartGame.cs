using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    public void Restart()
    {
        SceneManager.LoadScene(_button.gameObject.scene.name);
    }
    private void Awake()
    {
        _button.onClick.AddListener(Restart);
    }
}
