using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    Vector3 lastPos;

    [SerializeField] public AudioSource _walkSound;
    [SerializeField] HorizontalLayoutGroup HeartRow;
    public TextMeshProUGUI SpellName;
    public TextMeshProUGUI SpellCountText;
    public TextMeshProUGUI PotionName;
    public TextMeshProUGUI LevelValue;
    public TextMeshProUGUI ExperienceValue;
    public TextMeshProUGUI CoinValue;
    [SerializeField] Canvas PauseScreen;

    [NonSerialized] public static int maxPlayerSpellCount = 5;
    [NonSerialized] public static float SpellDamage = 5f;
    [NonSerialized] public static XRIDefaultInputActions input;
    [NonSerialized] public static float MaxPlayerHP = 100f;
    [NonSerialized] private bool isPaused;

    [NonSerialized] private static float playerHP = MaxPlayerHP; // очки здоровья;
    [NonSerialized] public static int PlayerXP = 0; // очки опыта
    [NonSerialized] public static int PlayerLevel = 0; // уровень игрока
    [NonSerialized] public static int PlayerBalance = 1000; // количество собранных кристаллов (баланс)
    [NonSerialized] public static int PlayerSpellCount = 0;

    [NonSerialized] public static bool HasPotion = false;
    [NonSerialized] public static bool IsInvincible = false;

    [NonSerialized] public static string PlayerSpell = "Fireball"; // текущее заклинание
    [NonSerialized] public static string PlayerPotion = "No Potion"; // текущее особое заклинание (зелье)

    public int KillCounter; // счетчик убийств
    [NonSerialized] public static float ExtraDamage = 0f;
    [NonSerialized] public int MaxKillsInLevel1 = 5; // максимальное количество убитых врагов на Level1
    [NonSerialized] public int MaxKillsInLevel2 = 7; // максимальное количество убитых врагов на Level2
    [NonSerialized] public int MaxKillsInLevel3 = 9; // максимальное количество убитых врагов на Level3
    [NonSerialized] public int MaxKillsInLevel4 = 12; // максимальное количество убитых врагов на Level4
    public static float PlayerHP
    {
        get => playerHP;
        set
        {
            if (value > MaxPlayerHP)
            {
                playerHP = MaxPlayerHP;
            }
            else if (value < 0)
            {
                playerHP = 0;
            }
            else
            {
                playerHP = value;
            }
        }
    }

    public void TogglePause()
    {
        if (this.gameObject.scene.name != "MainMenu" && this.gameObject.scene.name != "DeathScene")
        {
            PauseScreen.enabled = !PauseScreen.enabled;
            if (!isPaused)
            {
                Time.timeScale = 0f;
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
    public static void CheckPlayerLevel()
    {
        if (PlayerXP >= 40 && PlayerXP < 80)
        {
            PlayerLevel = 1;
            ExtraDamage = 2.5f;
            MaxPlayerHP = 120;
            maxPlayerSpellCount = 6;
        }
        if (PlayerXP >= 80 && PlayerXP < 160)
        {
            PlayerLevel = 2;
            ExtraDamage = 5f;
            MaxPlayerHP = 140;
            maxPlayerSpellCount = 7;
        }
        if (PlayerXP >= 160 && PlayerXP < 320)
        {
            PlayerLevel = 3;
            ExtraDamage = 7.5f;
            MaxPlayerHP = 160;
            maxPlayerSpellCount = 8;
        }
        if (PlayerXP >= 320 && PlayerXP < 640)
        {
            PlayerLevel = 4;
            ExtraDamage = 10f;
            MaxPlayerHP = 180;
            maxPlayerSpellCount = 9;
        }
        if (PlayerXP >= 640 && PlayerXP < 1280)
        {
            PlayerLevel = 5;
            ExtraDamage = 12.5f;
            MaxPlayerHP = 200;
            maxPlayerSpellCount = 10;
        }
        PlayerHP += 20;
        PlayerSpellCount += 1;
        Debug.Log($"Достигнут уровень {PlayerLevel}");
    }
    private void Awake()
    {
        isPaused = false;
        input = new XRIDefaultInputActions();
        input.XRILeftInteraction.Pause.performed += ctx => TogglePause();
        PauseScreen.enabled = false;
        PlayerSpellCount = maxPlayerSpellCount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Damager") && !IsInvincible)
        {
            Debug.Log($"Игроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от {other.gameObject.tag}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void SetHearts()
    {
        int heartCount = (int)(PlayerHP / 20);
        Image[] hearts = HeartRow.GetComponentsInChildren<Image>();
        foreach(Image h in hearts)
        {
            h.enabled = false;
        }
        for (int i = 0; i < heartCount; i++)
        {
            hearts[i].enabled = true;
            hearts[i].fillAmount = 1f;
        }
        if (PlayerHP % 20 != 0)
        {
            if (PlayerHP % 20 < 11)
            {
                hearts[heartCount].fillAmount = 0.5f;
            }
            hearts[heartCount].enabled = true;
        }
        if (PlayerHP <= 0)
        {
            hearts[0].enabled = false;
        }
    }
    private void SetHUDText()
    {
        if (PlayerSpellCount == 0)
        {
            PlayerSpell = "No Spell";
        }
        if (!HasPotion)
        {
            PlayerPotion = "No Potion";
        }
        PotionName.text = PlayerPotion;
        SpellName.text = PlayerSpell;
        LevelValue.text = PlayerLevel.ToString();
        SpellCountText.text = PlayerSpellCount.ToString();
        ExperienceValue.text = PlayerXP.ToString();
        CoinValue.text = PlayerBalance.ToString();
    }
    private void Update()
    {
        SetHearts();
        SetHUDText();
        if (PlayerHP <= 0)
        {
            Debug.Log($"Игрок умер");
            SceneManager.LoadScene("DeathScene");
            PlayerHP = MaxPlayerHP;
        }
        //isMoving();
    }
    private void isMoving()
    {
        Vector3 currPos = transform.position;
        if ((currPos.magnitude - lastPos.magnitude) > 0)
        {
            _walkSound.Play();
        }
        lastPos = currPos;
    }
}
