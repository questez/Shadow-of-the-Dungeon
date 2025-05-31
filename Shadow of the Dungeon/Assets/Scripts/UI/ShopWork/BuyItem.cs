using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuyItem : MonoBehaviour
{
    [SerializeField] Button button;
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
                    PlayerBehaviour.PlayerPotion = "Зелье силы";
                    PlayerBehaviour.HasPotion = 1;
                    break;
                case "Зелье исцеления":
                    PlayerBehaviour.PlayerPotion = "Зелье исцеления";
                    PlayerBehaviour.HasPotion = 1;
                    break;
                case "Зелье защиты":
                    PlayerBehaviour.PlayerPotion = "Зелье защиты";
                    PlayerBehaviour.HasPotion = 1;
                    break;
                default:
                    Debug.Log("Неверный ввод");
                    break;
            }
            SavingSystem.SaveMagic();
            Debug.Log($"Bought {itemText.text}");
            PlayerBehaviour.PlayerBalance -= itemPrice;
        }
    }
    private void Awake()
    {
        button.onClick.AddListener(BuyMagic);
        itemPrice = Convert.ToInt32(priceText.text);
    }
    private void Update()
    {
        if (PlayerBehaviour.PlayerSpell == itemText.text || PlayerBehaviour.PlayerPotion == itemText.text)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
