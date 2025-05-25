using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PutOnSword : MonoBehaviour
{
    [SerializeField] AudioSource equipSound;
    [SerializeField] GameObject sword;
    [SerializeField] Button equipButton;
    TextMeshProUGUI buttonText;       

    private void Start()
    {
        equipButton.onClick.AddListener(PutOnWeapon);
        buttonText = equipButton.GetComponentInChildren<TextMeshProUGUI>();               
    }
    
    public void PutOnWeapon()
    {
        equipSound.Play();
        if (sword.name == "Sword1")
        {
            PlayerBehaviour.EquippedSwordIndex = 0;
            Debug.Log("Надет меч 1");
            buttonText.text = "Equipped";
        }
        if (sword.name == "Sword2")
        {
            PlayerBehaviour.EquippedSwordIndex = 1;
            Debug.Log("Надет меч 2");
            buttonText.text = "Equipped";
        }
        if (sword.name == "Sword3")
        {
            PlayerBehaviour.EquippedSwordIndex = 2;
            Debug.Log("Надет меч 3");
            buttonText.text = "Equipped";
        }
    }
}
