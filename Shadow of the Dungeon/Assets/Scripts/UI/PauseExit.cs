using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseExit : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    AudioSource clickSound;
    private void Awake()
    {
        clickSound = GetComponent<AudioSource>();
        _button.onClick.AddListener(Exit);        
    }
    private void Exit()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}