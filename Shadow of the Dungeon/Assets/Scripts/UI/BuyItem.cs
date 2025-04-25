using UnityEngine;
using TMPro;

public class BuyItem : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] TMP_Text _text;
    private bool _isAvailible = true;
    public void Buy()
    {
        if (_isAvailible)
        {
            Debug.Log($"Bought {_text.text}");
            _isAvailible = false;
        }
    }
    private void Awake()
    {
        _button.onClick.AddListener(Buy);
    }
}
