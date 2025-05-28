using System;
using System.Collections;
using UnityEngine;

public class UsePotion : MonoBehaviour
{
    [SerializeField] GameObject StrengthEffect;
    [SerializeField] GameObject HealingEffect;
    [SerializeField] GameObject InvincibilityEffect;
    [NonSerialized] private XRIDefaultInputActions input;
    private void Start()
    {
        input = PlayerBehaviour.input;
        input.XRILeftInteraction.UsePotion.performed += ctx => UsePlayerPotion();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    IEnumerator Strength()
    {
        Debug.Log("Started Strength : " + Time.time);
        PlayerBehaviour.ExtraDamage += 50f;
        GameObject potionEffect = Instantiate(StrengthEffect, transform.position, transform.rotation);
        potionEffect.transform.SetParent(transform);
        yield return new WaitForSecondsRealtime(5);
        Destroy(potionEffect);
        PlayerBehaviour.ExtraDamage -= 50f;
        Debug.Log("Finished Strength : " + Time.time);
    }
    IEnumerator Invincibility()
    {
        Debug.Log("Started Invincibility : " + Time.time);
        PlayerBehaviour.IsInvincible = true;
        GameObject potionEffect = Instantiate(InvincibilityEffect, transform.position, transform.rotation);
        potionEffect.transform.SetParent(transform);
        yield return new WaitForSecondsRealtime(5);
        Destroy(potionEffect);
        PlayerBehaviour.IsInvincible = false;
        Debug.Log("Finished Invincibility : " + Time.time);
    }
    private void UsePlayerPotion()
    {
        if (PlayerBehaviour.HasPotion)
        {
            PlayerBehaviour.HasPotion = false;
            switch (PlayerBehaviour.PlayerPotion)
            {
                case "Strength":
                    StartCoroutine(Strength());
                    break;
                case "Healing":
                    PlayerBehaviour.PlayerHP = PlayerBehaviour.MaxPlayerHP;
                    Instantiate(HealingEffect, transform.position, transform.rotation);
                    break;
                case "Endurance":
                    StartCoroutine(Invincibility());
                    break;
                default:
                    Debug.Log("Неверный ввод");
                    break;
            }
        }
        else
        {
            Debug.Log("Нет зелий");
        }
    }
}
