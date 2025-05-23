using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    Vector3 lastPos;

    [SerializeField] AudioSource _walkSound;

    [SerializeField] HorizontalLayoutGroup HeartRow;
    public TextMeshProUGUI SpellName;
    public TextMeshProUGUI SpellCountText;
    public TextMeshProUGUI PotionName;
    public TextMeshProUGUI LevelValue;
    public TextMeshProUGUI ExperienceValue;
    public TextMeshProUGUI CoinValue;
    [SerializeField] Canvas PauseScreen;

    [NonSerialized] private bool isPaused;
    [NonSerialized] private XRIDefaultInputActions input;
    [NonSerialized] private static float maxPlayerHP = 100f;
    [NonSerialized] private static float playerHP = maxPlayerHP; // очки здоровья;
    [NonSerialized] private static int maxPlayerSpellCount = 5;
    public float PlayerHP
    {
        get => playerHP;
        set
        {
            if (value > maxPlayerHP)
            {
                playerHP = maxPlayerHP;
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
    [NonSerialized] public int PlayerXP = 0; // очки опыта
    [NonSerialized] public int PlayerLevel = 0; // уровень игрока
    [NonSerialized] public int PlayerBalance = 1000; // количество собранных кристаллов (баланс)
    [NonSerialized] public int PlayerSpellCount= maxPlayerSpellCount;
    [NonSerialized] public string PlayerSpell = "No spell"; // текущее заклинание
    [NonSerialized] public string PlayerPotion = "No potion"; // текущее особое заклинание (зелье)

    public int KillCounter; // счетчик убийств
    [NonSerialized] public float ExtraDamage = 0f;
    [NonSerialized] public int MaxKillsInLevel1 = 5; // максимальное количество убитых врагов на Level1
    [NonSerialized] public int MaxKillsInLevel2 = 7; // максимальное количество убитых врагов на Level2
    [NonSerialized] public int MaxKillsInLevel3 = 9; // максимальное количество убитых врагов на Level3
    [NonSerialized] public int MaxKillsInLevel4 = 12; // максимальное количество убитых врагов на Level4

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
    public void CheckPlayerLevel()
    {
        if (PlayerXP >= 40 && PlayerXP < 80)
        {
            PlayerLevel = 1;
            ExtraDamage = 2.5f;
            maxPlayerHP = 120;
            maxPlayerSpellCount = 6;
        }
        if (PlayerXP >= 80 && PlayerXP < 160)
        {
            PlayerLevel = 2;
            ExtraDamage = 5f;
            maxPlayerHP = 140;
            maxPlayerSpellCount = 7;
        }
        if (PlayerXP >= 160 && PlayerXP < 320)
        {
            PlayerLevel = 3;
            ExtraDamage = 7.5f;
            maxPlayerHP = 160;
            maxPlayerSpellCount = 8;
        }
        if (PlayerXP >= 320 && PlayerXP < 640)
        {
            PlayerLevel = 4;
            ExtraDamage = 10f;
            maxPlayerHP = 180;
            maxPlayerSpellCount = 9;
        }
        if (PlayerXP >= 640 && PlayerXP < 1280)
        {
            PlayerLevel = 5;
            ExtraDamage = 12.5f;
            maxPlayerHP = 200;
            maxPlayerSpellCount = 10;
        }
        PlayerHP += 20;
        PlayerSpellCount += 1;
        LevelValue.text = PlayerLevel.ToString();
        Debug.Log($"Достигнут уровень {PlayerLevel}");
    }
    private void Awake()
    {
        isPaused = false;
        input = new XRIDefaultInputActions();
        input.XRILeftInteraction.Pause.performed += ctx => TogglePause();
        SpellName.text = PlayerSpell;
        SpellCountText.text = PlayerSpellCount.ToString();
        PotionName.text = PlayerPotion;
        LevelValue.text = PlayerLevel.ToString();
        ExperienceValue.text = PlayerXP.ToString();
        CoinValue.text = PlayerBalance.ToString();
        PauseScreen.enabled = false;
        PlayerSpellCount = maxPlayerSpellCount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Damager"))
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
        if (PlayerHP < 0)
        {
            hearts[0].enabled = false;
        }
    }
    private void Update()
    {
        isDeath();
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
    private void isDeath()
    {
        SetHearts();
        if (PlayerHP <= 0)
        {
            Debug.Log($"Игрок умер");
            SceneManager.LoadScene("DeathScene");
        }
    }
}
