using UnityEngine;
using TMPro;
using System;

public class BuyItem : MonoBehaviour
{
    [SerializeField] GameObject currentItemRow;
    [SerializeField] GameObject nextItemRow;
    [SerializeField] UnityEngine.UI.Button button;
    [SerializeField] TMP_Text itemText;
    [SerializeField] TMP_Text priceText;
    private int itemPrice;

    [SerializeField] AudioSource _clickSound;

    public void BuyMagic()
    {        
        if (PlayerBehaviour.PlayerBalance >= itemPrice)
        {
            _clickSound.Play();
            switch (itemText.text)
            {
                case "Огненный шар":
                    PlayerBehaviour.PlayerSpell = "Огненный шар";
                    PlayerBehaviour.PlayerSpellCount = PlayerBehaviour.maxPlayerSpellCount;
                    break;
                case "Тёмный шар":
                    PlayerBehaviour.PlayerSpell = "Тёмный шар";
                    PlayerBehaviour.PlayerSpellCount = PlayerBehaviour.maxPlayerSpellCount;
                    break;
                case "Зелье силы":
                    PlayerBehaviour.PlayerPotion = "Сила";
                    PlayerBehaviour.HasPotion = 1;
                    break;
                case "Зелье исцеления":
                    PlayerBehaviour.PlayerPotion = "Исцеление";
                    PlayerBehaviour.HasPotion = 1;
                    break;
                case "Зелье неуяз-сти":
                    PlayerBehaviour.PlayerPotion = "Неуязвимость";
                    PlayerBehaviour.HasPotion = 1;
                    break;
                default:
                    Debug.Log("Неверный ввод");
                    break;
            }
            SavingSystem.SaveMagic();
            Debug.Log($"Bought {itemText.text}");
            PlayerBehaviour.PlayerBalance -= itemPrice;
            currentItemRow.SetActive(false);
            nextItemRow.SetActive(true);
        }
    }
    private void Awake()
    {
        button.onClick.AddListener(BuyMagic);
        itemPrice = Convert.ToInt32(priceText.text);
    }
}
