using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject DeathScreen;
    [SerializeField] HorizontalLayoutGroup HeartRow;
    [SerializeField] TMP_Text SpellName;
    [SerializeField] TMP_Text PotionName;
    [SerializeField] TMP_Text LevelValue;
    [SerializeField] TMP_Text ExperienceValue;
    [SerializeField] TMP_Text CoinValue;
    [SerializeField] TMP_Text ScoreValue;
    public float PlayerHP; // очки здоровь€
    public float PlayerXP = 0f; // очки опыта
    public int PlayerLevel = 0; // уровень игрока
    public int PlayerBalance = 0; // количество собранных кристаллов (баланс)
    [NonSerialized] public string PlayerSpell = "No spell"; // текущее заклинание
    [NonSerialized] public string PlayerPotion = "No potion"; // текуще особое заклинание (зелье)
    private void Awake()
    {
        if (DeathScreen != null)
        {
            DeathScreen.SetActive(false);
        }
        SpellName.text = PlayerSpell;
        PotionName.text = PlayerPotion;
        LevelValue.text = PlayerLevel.ToString();
        ExperienceValue.text = PlayerXP.ToString();
        CoinValue.text = PlayerBalance.ToString();
        //int heartCount = (int)(PlayerHP / 20);
        //int i = 0;
        //foreach (var h in HeartRow.GetComponents<Image>())
        //{
        //    h.gameObject.SetActive(false);
        //    i++;
        //    Debug.Log(i);
        //    if (i > 5)
        //    {
        //        break;
        //    }
        //}
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
    }
    private void Update()
    {
        if (PlayerHP <= 0)
        {
            Debug.Log($"»грок умер");
            ScoreValue.text = PlayerXP.ToString();
            DeathScreen.SetActive(true);
        }
    }
}
