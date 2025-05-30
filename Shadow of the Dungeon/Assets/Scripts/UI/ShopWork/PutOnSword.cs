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

    private void Awake()
    {
        equipButton.onClick.AddListener(PutOnWeapon);
        buttonText = equipButton.GetComponentInChildren<TextMeshProUGUI>();
        allSwordButtons.Add(this);        
    }

    private void Start()
    {
        CheckSwordConditions();
    }


    private void CheckSwordConditions()
    {
        int swordIndex = -1;
        if (sword.name == "Sword1")
        {
            swordIndex = 0;
        }
        else if (sword.name == "Sword2")
        {
            swordIndex = 1;
        }
        else if (sword.name == "Sword3")
        {
            swordIndex = 2;
        }

        if (swordIndex == PlayerBehaviour.EquippedSwordIndex)
        {
            buttonText.text = "Взято";
        }        
    }


    public void PutOnWeapon()
    {        
        if (sword.name == "Sword1" && buttonText.text == "Взять")
        {            
            PlayerBehaviour.EquippedSwordIndex = 0;
            equipSound.Play();
        }
        if (sword.name == "Sword2" && buttonText.text == "Взять")
        {
            PlayerBehaviour.EquippedSwordIndex = 1;
            equipSound.Play();
        }
        if (sword.name == "Sword3" && buttonText.text == "Взять")
        {
            PlayerBehaviour.EquippedSwordIndex = 2;
            equipSound.Play();          
        }        

        buttonText.text = "Взято";
        CkeckOtherButtons(this);

        SavingSystem.SaveEquipment();
    }

    private static void CkeckOtherButtons(PutOnSword activeButton)
    {
        foreach (PutOnSword button in allSwordButtons)
        {            
            if (button != activeButton && !button.buttonText.text.Contains("Купить"))
            {
                button.buttonText.text = "Взять";
            }
        }       
    }

}
