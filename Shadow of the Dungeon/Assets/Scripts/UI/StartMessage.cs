using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour
{
    [SerializeField] Button _continueButton;
    [SerializeField] GameObject startMessage, startMessage2;


    private void Awake()
    {
        startMessage.SetActive(false);
        startMessage2.SetActive(false);
        _continueButton.onClick.AddListener(CloseStartMessage);
    }


    public void CloseStartMessage()
    {
        FindAnyObjectByType<OpenDoor>().doorTrigger.enabled = true;
        startMessage.SetActive(false);
        startMessage2.SetActive(true);
    }    
}
