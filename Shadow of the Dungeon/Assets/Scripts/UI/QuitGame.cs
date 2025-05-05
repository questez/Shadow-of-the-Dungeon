using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

public class QuitGame : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    public void Quit()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
    private void Awake()
    {
        _button.onClick.AddListener(Quit);
    }
}
