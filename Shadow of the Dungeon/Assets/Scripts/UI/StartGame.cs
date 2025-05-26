using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;

    [SerializeField] AudioSource _clickSound;
    private void Awake()
    {
        _button.onClick.AddListener(StartNewGame);
    }
    public void StartNewGame()
    {
        _clickSound.Play();
        SavingSystem.DeleteAllSaves();
        SceneManager.LoadScene("StartRoom");
    }
}
