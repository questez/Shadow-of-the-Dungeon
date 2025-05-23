using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    AudioSource clickSound;
    [SerializeField] UnityEngine.UI.Button _button;
    private string _sceneName;
    private void Awake()
    {
        clickSound = GetComponent<AudioSource>();
        _sceneName = gameObject.scene.name;
        _button.onClick.AddListener(Restart);
        if (_sceneName == "StartRoom" || _sceneName == "SaveZone")
        {
            _button.interactable = false;
        }
    }
    private void Restart()
    {
        clickSound.Play();
        SceneManager.LoadScene(_sceneName);
        Time.timeScale = 1f;
    }
}
