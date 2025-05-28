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
            buttonText.text = "Equipped";
        }        

        Debug.Log("CheckSwordsConditions IS WORKING!");
    }


    public void PutOnWeapon()
    {        
        if (sword.name == "Sword1" && buttonText.text == "Equip")
        {            
            PlayerBehaviour.EquippedSwordIndex = 0;
            equipSound.Play();
            Debug.Log("Надет меч 1");
        }
        if (sword.name == "Sword2" && buttonText.text == "Equip")
        {
            PlayerBehaviour.EquippedSwordIndex = 1;
            equipSound.Play();
            Debug.Log("Надет меч 2");
        }
        if (sword.name == "Sword3" && buttonText.text == "Equip")
        {
            PlayerBehaviour.EquippedSwordIndex = 2;
            equipSound.Play();
            Debug.Log("Надет меч 3");            
        }        

        buttonText.text = "Equipped";
        CkeckOtherButtons(this);


        SavingSystem.SaveEquipment();
    }

    private static void CkeckOtherButtons(PutOnSword activeButton)
    {
        foreach (PutOnSword button in allSwordButtons)
        {            
            if (button != activeButton && !button.buttonText.text.Contains("Buy"))
            {
                button.buttonText.text = "Equip";
            }
        }       
    }

}
