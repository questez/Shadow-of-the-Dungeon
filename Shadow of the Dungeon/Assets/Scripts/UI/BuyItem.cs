using UnityEngine;
using TMPro;
using System;

public class BuyItem : MonoBehaviour
{
    [SerializeField] GameObject _currentItemRow;
    [SerializeField] GameObject _nextItemRow;
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] TextMeshProUGUI _itemText;
    [SerializeField] TextMeshProUGUI _priceText;
    private int _itemPrice;


    public void Buy()
    {
        if (PlayerBehaviour.PlayerBalance >= _itemPrice)
        {
            switch (_itemText.text)
            {
                case "Lightning x5":
                    PlayerBehaviour.PlayerSpell = "Lighning";
                    PlayerBehaviour.PlayerSpellCount = PlayerBehaviour.maxPlayerSpellCount;
                    break;
                case "Fireball x5":
                    PlayerBehaviour.PlayerSpell = "Fireball";
                    PlayerBehaviour.PlayerSpellCount = PlayerBehaviour.maxPlayerSpellCount;
                    break;
                case "Strength x1":
                    PlayerBehaviour.PlayerPotion = "Strength";
                    PlayerBehaviour.HasPotion = true;
                    break;
                case "Healing x1":
                    PlayerBehaviour.PlayerPotion = "Healing";
                    PlayerBehaviour.HasPotion = true;
                    break;
                case "Endurance x1":
                    PlayerBehaviour.PlayerPotion = "Endurance";
                    PlayerBehaviour.HasPotion = true;
                    break;
                default:
                    Debug.Log("Неверный ввод");
                    break;
            }
            Debug.Log($"Bought {_itemText.text}");
            PlayerBehaviour.PlayerBalance -= _itemPrice;
            _currentItemRow.SetActive(false);
            _nextItemRow.SetActive(true);
        }
    }
    private void Awake()
    {
        _button.onClick.AddListener(Buy);
        _itemPrice = Convert.ToInt32(_priceText.text);
    }
}
