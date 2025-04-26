using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] GameObject _currentScreen;
    [SerializeField] GameObject _homeScreen;
    private void Start()
    {
        if (_homeScreen != null)
        {
            _homeScreen.SetActive(false);
        }
    }
    public void CloseScreen()
    {
        if (_currentScreen != null)
        {
            _currentScreen.SetActive(false);
            _homeScreen.SetActive(true);
        }
    }
    private void Awake()
    {
        _button.onClick.AddListener(CloseScreen);
    }
}