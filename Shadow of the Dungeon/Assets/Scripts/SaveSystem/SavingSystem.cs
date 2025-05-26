using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SavingSystem : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] AudioSource clickSound;

    private void Awake()
    {        
        continueButton.onClick.AddListener(LoadFinishedLevel);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("lastLevelindex"))
        {
            continueButton.interactable = true;
        }
        else continueButton.interactable = false;
    }

    public static void SaveFinishedLevel(int index)
    {
        PlayerPrefs.SetInt("lastLevelindex", index);
        PlayerPrefs.Save();
    }

    public void LoadFinishedLevel()
    {        
        clickSound.Play();
        GameManager.lastLevelindex = PlayerPrefs.GetInt("lastLevelindex");
        SceneManager.LoadScene(GameManager.lastLevelindex);
    }

    public static void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
    }

}
