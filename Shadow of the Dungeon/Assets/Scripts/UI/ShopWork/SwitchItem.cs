using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchItem : MonoBehaviour
{
    [SerializeField] GameObject currentItemRow;
    [SerializeField] GameObject nextItemRow;
    [SerializeField] GameObject previousItemRow;
    [SerializeField] Button button;
    
    AudioSource clickSound;

    private void Awake()
    {
        clickSound = GameObject.Find("ClickSound").GetComponentInChildren<AudioSource>();
        button.onClick.AddListener(SwitchItemRow);
    }
    private void SwitchItemRow()
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText.text == ">")
        {            
            currentItemRow.SetActive(false);
            nextItemRow.SetActive(true);
        }
        if (buttonText.text == "<")
        {
            currentItemRow.SetActive(false);
            previousItemRow.SetActive(true);
        }
        else
        {
            Debug.Log("Неверный ввод");
        }
        if (clickSound != null)
        {
            clickSound.Play();
        }
    }
}
