using UnityEngine;
using UnityEngine.UI;

public class LevelEndMessage : MonoBehaviour
{
    [SerializeField] Button _continueButton;
    [SerializeField] GameObject levelEndMessage;

    private void Awake()
    {
        _continueButton.onClick.AddListener(CloseLevelEndMessage);
    }

    public void CloseLevelEndMessage()
    {        
        levelEndMessage.SetActive(false);        
    }
}
