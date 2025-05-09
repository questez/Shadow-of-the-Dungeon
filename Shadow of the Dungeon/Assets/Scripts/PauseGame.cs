using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] TMPro.TMP_Text _text;
    private bool isPaused = false;
    private void Awake()
    {
        _button.onClick.AddListener(TogglePause);
    }
    private void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            _text.text = "Resume";
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;
            _text.text = "Pause";
        }

    }
}
