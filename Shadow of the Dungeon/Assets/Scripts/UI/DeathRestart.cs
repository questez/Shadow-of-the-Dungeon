using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRestart : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] AudioSource _clickSound;
    private void Awake()
    {
        _button.onClick.AddListener(Restart);
    }    
    private void Restart()
    {
        _clickSound.Play();
        SceneManager.LoadScene(OpenDoor.lastLevelindex);
    }
}
