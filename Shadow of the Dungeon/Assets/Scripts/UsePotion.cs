using System;
using System.Collections;
using UnityEngine;

public class UsePotion : MonoBehaviour
{
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
        PlayerBehaviour.ExtraDamage += 50;
        yield return new WaitForSecondsRealtime(5);
        PlayerBehaviour.ExtraDamage -= 50;
        Debug.Log("Finished Strength : " + Time.time);
    }
    IEnumerator Invincibility()
    {
        Debug.Log("Started Invincibility : " + Time.time);
        PlayerBehaviour.IsInvincible = true;
        yield return new WaitForSecondsRealtime(5);
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
