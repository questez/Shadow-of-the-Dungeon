using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    Vector3 lastPos;
    float movementThreshold = 0.008f; // минимальное смещение для звука ходьбы

    [SerializeField] AudioSource walkingSound;
    [SerializeField] AudioSource HitPlayerSound;
    [SerializeField] AudioSource clickPauseButton;

    [SerializeField] HorizontalLayoutGroup HeartRow;
    public TMP_Text SpellName;
    public TMP_Text PotionName;
    public TMP_Text LevelValue;
    public TMP_Text ExperienceValue;
    public TMP_Text CoinValue;
    [SerializeField] Canvas PauseScreen;

    private bool isPaused;
    private XRIDefaultInputActions input;

    [NonSerialized] public float PlayerHP = 100f; // очки здоровья
    [NonSerialized] public static int PlayerXP = 0; // очки опыта
    [NonSerialized] public int PlayerXPInLevel = 0; // очки опыта, собранные на конкретном уровне
    [NonSerialized] public static int PlayerLevel = 0; // уровень игрока
    [NonSerialized] public static int PlayerBalance = 0; // количество собранных кристаллов (баланс)
    [NonSerialized] public int PlayerBalanceInLevel = 0; // количество собранных кристаллов на конкретном уровне
    [NonSerialized] public string PlayerSpell = "No spell"; // текущее заклинание
    [NonSerialized] public string PlayerPotion = "No potion"; // текущее особое заклинание (зелье)


    public int KillCounter; // счетчик убийств
    [NonSerialized] public int MaxKillsInLevel1 = 5; // максимальное количество убитых врагов на Level1
    [NonSerialized] public int MaxKillsInLevel2 = 7; // максимальное количество убитых врагов на Level2
    [NonSerialized] public int MaxKillsInLevel3 = 9; // максимальное количество убитых врагов на Level3
    [NonSerialized] public int MaxKillsInLevel4 = 12; // максимальное количество убитых врагов на Level4

    public static int EquippedSwordIndex = 0; // индекс надетого меча (0 = Sword1, 1 = Sword2, 2 = Sword3)

    private void Awake()
    {
        lastPos = transform.position;
        isPaused = false;
        input = new XRIDefaultInputActions();
        input.XRILeftInteraction.Pause.performed += ctx => TogglePause();
        SpellName.text = PlayerSpell;
        PotionName.text = PlayerPotion;
        LevelValue.text = PlayerLevel.ToString();
        ExperienceValue.text = PlayerXP.ToString();
        CoinValue.text = PlayerBalance.ToString();
        PauseScreen.enabled = false;
        SetHearts();
        if (this.gameObject.scene.name != "DeathScene")
        {
            PlayerPrefs.DeleteKey("CurrentScore");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Damager"))
        {
            HitPlayerSound.Play();
            Debug.Log($"Игроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от {other.gameObject.tag}!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
            SetHearts();
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
                clickPauseButton.Play();
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
    private void Update()
    {
        isDeath();
        CheckLevel();
        PlayWalkingSound();
        SetHearts();
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
            Debug.Log($"Игрок умер");
            SceneManager.LoadScene("DeathScene");
        }
    }

    private void CheckLevel()
    {
        if (PlayerXP >= 35)
        {
            PlayerLevel = 1;
            LevelValue.text = "1";
            PlayerHP = 120;
            SetHearts();
        }
        if (PlayerXP >= 70)
        {
            PlayerLevel = 2;
            LevelValue.text = "2";
            PlayerHP = 140;
            SetHearts();
        }
        if (PlayerXP >= 105)
        {
            PlayerLevel = 3;
            LevelValue.text = "3";
            PlayerHP = 160;
            SetHearts();
        }
        if (PlayerXP >= 140)
        {
            PlayerLevel = 4;
            LevelValue.text = "4";
            PlayerHP = 180;
            SetHearts();
        }
        if (PlayerXP >= 220)
        {
            PlayerLevel = 5;
            LevelValue.text = "5";
            PlayerHP = 200;
            SetHearts();            
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
