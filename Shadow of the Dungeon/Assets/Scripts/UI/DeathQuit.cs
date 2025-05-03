using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathQuit : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    public void QuitOnDeath()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Awake()
    {
        _button.onClick.AddListener(QuitOnDeath);
    }
}