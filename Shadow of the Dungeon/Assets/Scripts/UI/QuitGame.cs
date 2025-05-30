using UnityEditor;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;

    [SerializeField] AudioSource _clickSound;
    public void Quit()
    {
        _clickSound.Play();
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
    private void Awake()
    {
        _button.onClick.AddListener(Quit);
    }
}
