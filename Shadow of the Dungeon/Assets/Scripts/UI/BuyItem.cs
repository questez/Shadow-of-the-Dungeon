using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
using System;

public class BuyItem : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] TMP_Text _text;
    [SerializeField] TMP_Text _priceText;
    [SerializeField] TMP_Text _coinValue;
    [SerializeField] XROrigin _player;
    private bool _isAvailible = true;
    private PlayerBehaviour _pb;
    private int _itemPrice;


    public void Buy()
    {
        if (_isAvailible && _pb.PlayerBalance >= _itemPrice)
        {
            Debug.Log($"Bought {_text.text}");
            _isAvailible = false;
            _pb.PlayerBalance -= _itemPrice;
            _coinValue.text = _pb.PlayerBalance.ToString();
        }
    }
    private void Awake()
    {
        _button.onClick.AddListener(Buy);
        _pb = _player.GetComponentInParent<PlayerBehaviour>();
        _itemPrice = Convert.ToInt32(_priceText.text);
    }
}
