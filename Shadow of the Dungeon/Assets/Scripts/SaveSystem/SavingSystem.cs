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
        SaveMagic();
        PlayerPrefs.Save();
    }

    public void LoadFinishedLevel()
    {        
        clickSound.Play();
        GameManager.lastLevelindex = PlayerPrefs.GetInt("lastLevelindex") - 1;
        PlayerBehaviour.PlayerXP = PlayerPrefs.GetInt("PlayerXP");
        PlayerBehaviour.PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
        PlayerBehaviour.EquippedSwordIndex = PlayerPrefs.GetInt("EquippedSword");
        LoadMagic();
        SceneManager.LoadScene("SaveZone");
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

        PlayerPrefs.Save();
    }

    public static void SaveMagic() // сохранение купленных и потраченных зелий и заклинаний
    {        
        PlayerPrefs.SetString("lastPlayerSpell", PlayerBehaviour.PlayerSpell);
        PlayerPrefs.SetString("lastPlayerPotion", PlayerBehaviour.PlayerPotion);
        PlayerPrefs.SetInt("lastPlayerSpellCount", PlayerBehaviour.PlayerSpellCount);
        PlayerPrefs.SetInt("lastHasPotion", PlayerBehaviour.HasPotion);

        PlayerPrefs.Save();
    }
    public static void LoadMagic()
    {
        PlayerBehaviour.PlayerSpell = PlayerPrefs.GetString("lastPlayerSpell");
        PlayerBehaviour.PlayerPotion = PlayerPrefs.GetString("lastPlayerPotion");
        PlayerBehaviour.PlayerSpellCount = PlayerPrefs.GetInt("lastPlayerSpellCount");
        PlayerBehaviour.HasPotion = PlayerPrefs.GetInt("lastHasPotion");
    }

    


    public static void LoadShop()
    {
        BuySword.isPurchased[1] = PlayerPrefs.GetInt("purchased_sword2");
        BuySword.isPurchased[2] = PlayerPrefs.GetInt("purchased_sword3");
    }

    public static void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
    }

}
