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
        if (gameObject.scene.name == "StartRoom")
        {
            _button.interactable = false;
        }
    }
    private void Exit()
    {
        clickSound.Play();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}