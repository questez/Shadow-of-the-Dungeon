using UnityEngine;

public class SwitchScreen : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] GameObject _newScreen;
    [SerializeField] GameObject _oldScreen;

    [SerializeField] AudioSource _clickSound;
    private void Start()
    {
        if (_newScreen != null)
        {
            _newScreen.SetActive(false);
        }
    }
    public void OpenScreen()
    {
        if (_newScreen != null)
        {
            _clickSound.Play();
            _newScreen.SetActive(true);
            _oldScreen.SetActive(false);
        }
    }
    private void Awake()
    {
        _button.onClick.AddListener(OpenScreen);
    }
}
