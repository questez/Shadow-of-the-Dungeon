using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SavingSystem : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] Button restartButton;
    [SerializeField] AudioSource clickSound;
    private void Awake()
    {
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(LoadFinishedLevel);
        } 
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(LoadRestartLevel);
        }            
    }
    private void Start()
    {
        if (continueButton != null)
        {
            if (PlayerPrefs.HasKey("lastLevelindex"))
            {
                continueButton.interactable = true;
            }
            else continueButton.interactable = false;
        }        
    }
    public static void SaveFinishedLevel(int lastLevel)
    {
        PlayerPrefs.SetInt("lastLevelindex", lastLevel); // сохранение последнего пройденного уровня
        PlayerPrefs.SetInt("PlayerXP", PlayerBehaviour.PlayerXP); // сохранение последних набранных очков опыта
        PlayerPrefs.SetInt("PlayerLevel", PlayerBehaviour.PlayerLevel); // сохранение последнего полученного уровня игрока
        PlayerPrefs.SetInt("PlayerBalance", PlayerBehaviour.PlayerBalance); // сохранение последнего баланса игрока        
        SaveMagic();
        PlayerPrefs.Save();
    }
    public void LoadFinishedLevel()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
        GameManager.lastLevelindex = PlayerPrefs.GetInt("lastLevelindex") - 1;
        PlayerBehaviour.PlayerXP = PlayerPrefs.GetInt("PlayerXP");
        PlayerBehaviour.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        PlayerBehaviour.EquippedSwordIndex = PlayerPrefs.GetInt("EquippedSword");
        PlayerBehaviour.PlayerBalance = PlayerPrefs.GetInt("PlayerBalance");
        LoadMagic();
        PlayerBehaviour.CheckPlayerLevel();
        SceneManager.LoadScene("SaveZone");
    }
    public void LoadRestartLevel()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
        PlayerBehaviour.PlayerXP = PlayerPrefs.GetInt("PlayerXP");
        PlayerBehaviour.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        PlayerBehaviour.EquippedSwordIndex = PlayerPrefs.GetInt("EquippedSword");
        PlayerBehaviour.PlayerBalance = PlayerPrefs.GetInt("PlayerBalance");
        PlayerBehaviour.CheckPlayerLevel();
        LoadMagic();
    }
    public static void SaveEquipment()
    {
        PlayerPrefs.SetInt("EquippedSword", PlayerBehaviour.EquippedSwordIndex); // сохранение последнего примененного меча
        PlayerPrefs.Save();
    }    
    public static void SaveShop()
    {
        // сохранение купленных мечей
        PlayerPrefs.SetInt("purchased_sword2", BuySword.isPurchased[1]); 
        PlayerPrefs.SetInt("purchased_sword3", BuySword.isPurchased[2]);
        PlayerPrefs.SetInt("PlayerBalance", PlayerBehaviour.PlayerBalance);
        PlayerPrefs.Save();
    }
    public static void LoadShop()
    {
        BuySword.isPurchased[1] = PlayerPrefs.GetInt("purchased_sword2");
        BuySword.isPurchased[2] = PlayerPrefs.GetInt("purchased_sword3");
    }
    public static void SaveMagic() // сохранение купленных и потраченных зелий и заклинаний
    {        
        PlayerPrefs.SetString("lastPlayerSpell", PlayerBehaviour.PlayerSpell);
        PlayerPrefs.SetString("lastPlayerPotion", PlayerBehaviour.PlayerPotion);
        PlayerPrefs.SetInt("lastPlayerSpellCount", PlayerBehaviour.PlayerSpellCount);
        PlayerPrefs.SetInt("lastHasPotion", PlayerBehaviour.HasPotion);
        PlayerPrefs.SetInt("PlayerBalance", PlayerBehaviour.PlayerBalance);
        PlayerPrefs.Save();
    }
    public static void LoadMagic()
    {
        PlayerBehaviour.PlayerSpell = PlayerPrefs.GetString("lastPlayerSpell");
        PlayerBehaviour.PlayerPotion = PlayerPrefs.GetString("lastPlayerPotion");
        PlayerBehaviour.PlayerSpellCount = PlayerPrefs.GetInt("lastPlayerSpellCount");
        PlayerBehaviour.HasPotion = PlayerPrefs.GetInt("lastHasPotion");
    }    
    public static void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
    }
}
