using System;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndMessage : MonoBehaviour
{
    AudioSource clickSound;

    [SerializeField] Button _continueButton;
    [SerializeField] Canvas levelEndCanvas;

    public TextMeshProUGUI score;
    public TextMeshProUGUI collected_coins;

    [NonSerialized] public PlayerBehaviour pb;

    private void Awake()
    {        
        clickSound = levelEndCanvas.GetComponentInChildren<AudioSource>();
        _continueButton.onClick.AddListener(CloseMessage);
        levelEndCanvas.enabled = false;
        pb = FindAnyObjectByType<XROrigin>().GetComponent<PlayerBehaviour>();
    }
    
    public void ShowMessage()
    {
        score.text = pb.PlayerXPInLevel.ToString();
        collected_coins.text = pb.PlayerBalanceInLevel.ToString();
        levelEndCanvas.enabled = true;
    }

    public void CloseMessage()
    {
        clickSound.Play();
        levelEndCanvas.enabled = false;        
    }
}
