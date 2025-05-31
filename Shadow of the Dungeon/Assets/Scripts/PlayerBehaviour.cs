using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    Vector3 lastPos;
    float movementThreshold = 0.008f; // минимальное смещение дл€ звука ходьбы

    [SerializeField] AudioSource walkingSound;
    [SerializeField] AudioSource HitPlayerSound;
    [SerializeField] AudioSource clickPauseButton;

    [SerializeField] HorizontalLayoutGroup HeartRow;
    public TextMeshProUGUI SpellName;
    public TextMeshProUGUI SpellCountText;
    public TextMeshProUGUI PotionName;
    public TextMeshProUGUI LevelValue;
    public TextMeshProUGUI ExperienceValue;
    public TextMeshProUGUI CoinValue;
    [SerializeField] Canvas PauseScreen;

    [NonSerialized] public static int maxPlayerSpellCount = 5;
    [NonSerialized] public static float FireballDamage = 10f;
    [NonSerialized] public static float HexDamage = 20f;
    [NonSerialized] public static float MaxPlayerHP = 100f;
    [NonSerialized] public static XRIDefaultInputActions input;
    [NonSerialized] private bool isPaused;

    [NonSerialized] private static float playerHP = MaxPlayerHP; // очки здоровь€;
    [NonSerialized] public static int PlayerXP = 0; // очки опыта
    [NonSerialized] public static int PlayerLevel = 0; // уровень игрока
    [NonSerialized] public static int PlayerBalance = 1000; // количество собранных кристаллов (баланс)
    [NonSerialized] public static int PlayerSpellCount = 0;

    [NonSerialized] public static int HasPotion = 0;
    [NonSerialized] public static bool IsInvincible = false;

    [NonSerialized] public static string PlayerSpell = "Ќет «аклинани€"; // текущее заклинание
    [NonSerialized] public static string PlayerPotion = "Ќет «ель€"; // текущее особое заклинание (зелье)

    public int KillCounter = 0; // счетчик убийств
    [NonSerialized] public static float ExtraDamage = 0f;
    [NonSerialized] public int PlayerBalanceInLevel = 0; // количество собранных кристаллов на локации
    [NonSerialized] public int PlayerXPInLevel = 0; // очки опыта на конкретном уровне
    [NonSerialized] public int MaxKillsInLevel1 = 5; // максимальное количество убитых врагов на Level1
    [NonSerialized] public int MaxKillsInLevel2 = 7; // максимальное количество убитых врагов на Level2
    [NonSerialized] public int MaxKillsInLevel3 = 9; // максимальное количество убитых врагов на Level3
    [NonSerialized] public int MaxKillsInLevel4 = 12; // максимальное количество убитых врагов на Level4

    public static int EquippedSwordIndex = 0; // индекс надетого меча (0 = Sword1, 1 = Sword2, 2 = Sword3)
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
                if (clickPauseButton != null)
                {
                    clickPauseButton.Play();
                }                
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
    public static void CheckPlayerLevel()
    {
        if (PlayerXP >= 35 && PlayerXP < 70)
        {
            PlayerLevel = 1;
            ExtraDamage = 2.5f;
            MaxPlayerHP = 120;
            maxPlayerSpellCount = 6;
        }
        if (PlayerXP >= 70 && PlayerXP < 105)
        {
            PlayerLevel = 2;
            ExtraDamage = 5f;
            MaxPlayerHP = 140;
            maxPlayerSpellCount = 7;
        }
        if (PlayerXP >= 105 && PlayerXP < 140)
        {
            PlayerLevel = 3;
            ExtraDamage = 7.5f;
            MaxPlayerHP = 160;
            maxPlayerSpellCount = 8;
        }
        if (PlayerXP >= 140 && PlayerXP < 220)
        {
            PlayerLevel = 4;
            ExtraDamage = 10f;
            MaxPlayerHP = 180;
            maxPlayerSpellCount = 9;
        }
        if (PlayerXP >= 220)
        {
            PlayerLevel = 5;
            ExtraDamage = 12.5f;
            MaxPlayerHP = 200;
            maxPlayerSpellCount = 10;
        }
        Debug.Log($"ƒостигнут уровень {PlayerLevel}");
    }
    private void Awake()
    {
        lastPos = transform.position;
        isPaused = false;
        input = new XRIDefaultInputActions();
        input.XRILeftInteraction.Pause.performed += ctx => TogglePause();
        PauseScreen.enabled = false;
        PlayerHP = MaxPlayerHP;
        if (this.gameObject.scene.name != "DeathScene")
        {
            PlayerPrefs.DeleteKey("CurrentScore");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Damager") && !IsInvincible)
        {
            HitPlayerSound.Play();
            Debug.Log($"»гроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от {other.gameObject.tag}!");
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
            PlayerSpell = "Ќет «аклинани€";
            SpellCountText.enabled = false;
        }
        else
        {
            SpellCountText.enabled = true;
        }
        if (HasPotion == 0)
        {
            PlayerPotion = "Ќет «ель€";
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
        PlayWalkingSound();
        SetHearts();
        SetHUDText();
        isDeath();
    }

    private void PlayWalkingSound()
    {
        float distanceMoved = Vector3.Distance(lastPos, transform.position);
        bool isMoving = distanceMoved > movementThreshold;
        lastPos = transform.position;
        if (isMoving && !walkingSound.isPlaying)
        {
            walkingSound.Play();
            //Debug.Log("WALKINGSOUND!");
        }
        else if (!isMoving && walkingSound.isPlaying)
        {
            walkingSound.Stop();
            //Debug.Log("STOPSOUND!");
        }
    }

    private void isDeath()
    {
        if (PlayerHP <= 0)
        {
            Debug.Log($"»грок умер");
            SceneManager.LoadScene("DeathScene");
            PlayerHP = MaxPlayerHP;
        }
    }

    public void SetCurrentScore()
    {
        PlayerPrefs.SetInt("CurrentScore", PlayerXPInLevel);
        PlayerPrefs.Save();
    }
    public int GetCurrentScore()
    {
        PlayerXPInLevel = PlayerPrefs.GetInt("CurrentScore");
        return PlayerXPInLevel;
    }


}
