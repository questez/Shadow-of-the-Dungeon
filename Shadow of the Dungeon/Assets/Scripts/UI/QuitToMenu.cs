using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] AudioSource _clickSound;
    private void Awake()
    {
        _button.onClick.AddListener(Quit);
    }
    private void Quit()
    {
        _clickSound.Play();
        SceneManager.LoadScene("MainMenu");
    }
}