using System;
using System.Collections;
using UnityEngine;

public class UsePotion : MonoBehaviour
{
    [SerializeField] GameObject StrengthEffect;
    [SerializeField] GameObject HealingEffect;
    [SerializeField] GameObject InvincibilityEffect;
    [NonSerialized] private XRIDefaultInputActions input;
    [NonSerialized] private Vector3 effectPosition;
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
    private void UsePlayerPotion()
    {
        if (PlayerBehaviour.HasPotion == 1)
        {
            PlayerBehaviour.HasPotion = 0;
            switch (PlayerBehaviour.PlayerPotion)
            {
                case "Зелье силы":
                    effectPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                    StartCoroutine(Strength());
                    break;
                case "Зелье исцеления":
                    effectPosition = new Vector3(transform.position.x, transform.position.y + 1.75f, transform.position.z);
                    PlayerBehaviour.PlayerHP = PlayerBehaviour.MaxPlayerHP;
                    Instantiate(HealingEffect, effectPosition, transform.rotation);
                    break;
                case "Зелье защиты":
                    effectPosition = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
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
    IEnumerator Strength()
    {
        Debug.Log("Started Strength : " + Time.time);
        PlayerBehaviour.ExtraDamage += 50f;
        GameObject potionEffect = Instantiate(StrengthEffect, effectPosition, transform.rotation);
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
        GameObject potionEffect = Instantiate(InvincibilityEffect, effectPosition, transform.rotation);
        potionEffect.transform.SetParent(transform);
        yield return new WaitForSecondsRealtime(5);
        Destroy(potionEffect);
        PlayerBehaviour.IsInvincible = false;
        Debug.Log("Finished Invincibility : " + Time.time);
    }
}
