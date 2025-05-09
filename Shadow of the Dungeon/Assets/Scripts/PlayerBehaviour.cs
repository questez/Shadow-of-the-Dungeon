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
    public float PlayerHP; // очки здоровь€
    public int PlayerXP = 0; // очки опыта
    public int PlayerLevel = 0; // уровень игрока
    public int PlayerBalance = 0; // количество собранных кристаллов (баланс)
    [NonSerialized] public string PlayerSpell = "No spell"; // текущее заклинание
    [NonSerialized] public string PlayerPotion = "No potion"; // текуще особое заклинание (зелье)
    private void Awake()
    {
        SpellName.text = PlayerSpell;
        PotionName.text = PlayerPotion;
        LevelValue.text = PlayerLevel.ToString();
        ExperienceValue.text = PlayerXP.ToString();
        CoinValue.text = PlayerBalance.ToString();
        SetHearts();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spider"))
        {
            Debug.Log($"»гроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от Spider!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("Golem"))
        {
            Debug.Log($"»гроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от Golem!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("Minotaur"))
        {
            Debug.Log($"»гроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от Minotaur!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        if (other.gameObject.CompareTag("Skeleton"))
        {
            Debug.Log($"»гроку нанесен урон {other.GetComponentInParent<EnemyStateManager>().EnemyDamage} от Skeleton!");
            PlayerHP -= other.GetComponentInParent<EnemyStateManager>().EnemyDamage;
        }
        SetHearts();
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
        if (PlayerHP <= 0)
        {
            Debug.Log($"»грок умер");
            SceneManager.LoadScene("InterimScene");
        }

    }
}
