using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
using System;

public class BuyItem : MonoBehaviour
{
    [SerializeField] GameObject _currentItemRow;
    [SerializeField] GameObject _nextItemRow;
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] TMP_Text _itemText;
    [SerializeField] TMP_Text _spellText;
    [SerializeField] TMP_Text _potionText;
    [SerializeField] TMP_Text _priceText;
    [SerializeField] TMP_Text _coinText;
    [SerializeField] XROrigin _player;
    private PlayerBehaviour _pb;
    private int _itemPrice;


    public void Buy()
    {
        if (_pb.PlayerBalance >= _itemPrice)
        {
            switch (_itemText.text)
            {
                case "Lightning x5":
                    _pb.PlayerSpell = "Lighning";
                    _spellText.text = "Lighning";
                    break;
                case "Fireball x5":
                    _pb.PlayerSpell = "Fireball";
                    _spellText.text = "Fireball";
                    break;
                case "Strength x1":
                    _pb.PlayerPotion = "Strength";
                    _potionText.text = "Strength";
                    break;
                case "Healing x1":
                    _pb.PlayerSpell = "Healing";
                    _potionText.text = "Healing";
                    break;
                case "Endurance x1":
                    _pb.PlayerSpell = "Endurance";
                    _potionText.text = "Endurance";
                    break;
                default:
                    Debug.Log("Неверный ввод");
                    break;
            }
            Debug.Log($"Bought {_itemText.text}");
            _pb.PlayerBalance -= _itemPrice;
            _coinText.text = _pb.PlayerBalance.ToString();
            _currentItemRow.SetActive(false);
            _nextItemRow.SetActive(true);
        }
    }
    private void Awake()
    {
        _button.onClick.AddListener(Buy);
        _pb = _player.GetComponentInParent<PlayerBehaviour>();
        _itemPrice = Convert.ToInt32(_priceText.text);
    }
}
