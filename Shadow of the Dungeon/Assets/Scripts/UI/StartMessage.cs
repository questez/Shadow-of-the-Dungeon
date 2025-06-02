using UnityEngine;
using UnityEngine.UI;

public class StartMessage : MonoBehaviour
{
    [SerializeField] Button _continueButton;
    [SerializeField] GameObject startMessage, startMessage2;

    [SerializeField] AudioSource _clickSound;


    private void Awake()
    {
        startMessage.SetActive(false);
        startMessage2.SetActive(false);
        _continueButton.onClick.AddListener(CloseStartMessage);
    }

    private void Start()
    {
        SavingSystem.SaveFinishedLevel(GameManager.lastLevelindex);
    }


    public void CloseStartMessage()
    {
        _clickSound.Play();
        FindAnyObjectByType<OpenDoor>().doorTrigger.enabled = true;
        startMessage.SetActive(false);
        startMessage2.SetActive(true);
    }    
}
