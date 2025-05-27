using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PutOnSword: MonoBehaviour
{
    [SerializeField] AudioSource equipSound;
    [SerializeField] GameObject sword;
    [SerializeField] Button equipButton;
    TextMeshProUGUI buttonText;

    private static List<PutOnSword> allSwordButtons = new List<PutOnSword>();

    private void Start()
    {
        equipButton.onClick.AddListener(PutOnWeapon);
        buttonText = equipButton.GetComponentInChildren<TextMeshProUGUI>();
        allSwordButtons.Add(this);
    }
    
    public void PutOnWeapon()
    {        
        if (sword.name == "Sword1" && buttonText.text == "Equip")
        {            
            PlayerBehaviour.EquippedSwordIndex = 0;
            SavingSystem.SaveEquipment();
            equipSound.Play();
            Debug.Log("Надет меч 1");
        }
        if (sword.name == "Sword2" && buttonText.text == "Equip")
        {
            PlayerBehaviour.EquippedSwordIndex = 1;
            SavingSystem.SaveEquipment();
            equipSound.Play();
            Debug.Log("Надет меч 2");
        }
        if (sword.name == "Sword3" && buttonText.text == "Equip")
        {
            PlayerBehaviour.EquippedSwordIndex = 2;
            SavingSystem.SaveEquipment();
            equipSound.Play();
            Debug.Log("Надет меч 3");            
        }

        buttonText.text = "Equipped";

        ResetOtherButtons(this);
    }

    private static void ResetOtherButtons(PutOnSword activeButton)
    {
        foreach (PutOnSword swordButton in allSwordButtons)
        {
            if (swordButton != activeButton && !swordButton.buttonText.text.Contains("Buy"))
            {
                swordButton.buttonText.text = "Equip";
            }
        }
    }

}
