using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    private void Awake()
    {
        _button.onClick.AddListener(Quit);
    }
}
