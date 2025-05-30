using UnityEngine;
using TMPro;
using System;

public class BuyItem : MonoBehaviour
{
    [SerializeField] GameObject _currentItemRow;
    [SerializeField] GameObject _nextItemRow;
    [SerializeField] UnityEngine.UI.Button _button;
    [SerializeField] TMP_Text _itemText;
    [SerializeField] TMP_Text _priceText;
    private int _itemPrice;

    [SerializeField] AudioSource _clickSound;

    public void BuyMagic()
    {        
        if (PlayerBehaviour.PlayerBalance >= _itemPrice)
        {
            _clickSound.Play();
            switch (_itemText.text)
            {
                case "Lightning x5":
                    PlayerBehaviour.PlayerSpell = "Lighning";
                    break;
                case "Fireball x5":
                    PlayerBehaviour.PlayerSpell = "Fireball";
                    break;
                case "Strength x1":
                    PlayerBehaviour.PlayerPotion = "Strength";
                    break;
                case "Healing x1":
                    PlayerBehaviour.PlayerSpell = "Healing";
                    break;
                case "Endurance x1":
                    PlayerBehaviour.PlayerSpell = "Endurance";
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
        _button.onClick.AddListener(BuyMagic);
        _itemPrice = Convert.ToInt32(_priceText.text);
    }
}
