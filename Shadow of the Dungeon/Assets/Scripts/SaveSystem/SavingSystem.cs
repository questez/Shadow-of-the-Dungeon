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

    public static void SaveFinishedLevel(int lastLevel)
    {
        PlayerPrefs.SetInt("lastLevelindex", lastLevel); // сохранение последнего пройденного уровня
        PlayerPrefs.SetInt("PlayerXP", PlayerBehaviour.PlayerXP); // сохранение последних набранных очков опыта
        PlayerPrefs.SetInt("PlayerLevel", PlayerBehaviour.PlayerLevel); // сохранение последнего полученного уровня игрока
        PlayerPrefs.Save();
    }

    public void LoadFinishedLevel()
    {        
        clickSound.Play();
        GameManager.lastLevelindex = PlayerPrefs.GetInt("lastLevelindex") - 1;
        PlayerBehaviour.PlayerXP = PlayerPrefs.GetInt("PlayerXP");
        PlayerBehaviour.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        PlayerBehaviour.EquippedSwordIndex = PlayerPrefs.GetInt("EquippedSword");
        SceneManager.LoadScene("SaveZone");
    }

    public static void SaveEquipment()
    {
        PlayerPrefs.SetInt("EquippedSword", PlayerBehaviour.EquippedSwordIndex);
        PlayerPrefs.Save();
    }

    public static void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
    }

}
