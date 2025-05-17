using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] HorizontalLayoutGroup HeartRow;
    [SerializeField] TMP_Text SpellName;
    [SerializeField] TMP_Text PotionName;
    [SerializeField] TMP_Text LevelValue;
    [SerializeField] TMP_Text ExperienceValue;
    [SerializeField] TMP_Text CoinValue;
    [SerializeField] Canvas PauseScreen;

    [NonSerialized] private bool isPaused;
    [NonSerialized] private XRIDefaultInputActions input;
    public float PlayerHP = 100f; // очки здоровья
    [NonSerialized] public int PlayerXP = 0; // очки опыта
    [NonSerialized] public int PlayerLevel = 0; // уровень игрока
    [NonSerialized] public int PlayerBalance = 1000; // количество собранных кристаллов (баланс)
    [NonSerialized] public string PlayerSpell = "No spell"; // текущее заклинание
    [NonSerialized] public string PlayerPotion = "No potion"; // текущее особое заклинание (зелье)

    public int KillCounter; // счетчик убийств
    public int MaxKillsInLevel; // максимальное количество убитых врагов на сцене

    private void Awake()
    {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpiderDamager"))
        {
            Debug.Log($"Игроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от Spider!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("GolemDamager"))
        {
            Debug.Log($"Игроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от Golem!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("MinotaurDamager"))
        {
            Debug.Log($"Игроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от Minotaur!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("SkeletonDamager"))
        {
            Debug.Log($"Игроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от Skeleton!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        SetHearts();
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
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
    private void Update()
    {
        if (PlayerHP <= 0)
        {
            Debug.Log($"Игрок умер");
            SceneManager.LoadScene("DeathScene");
        }

    }
}
