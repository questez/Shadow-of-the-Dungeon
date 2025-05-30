using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] GameObject fireball;
    [SerializeField] GameObject hexFireball;
    [SerializeField] Transform spawnpoint;
    [SerializeField] TextMeshProUGUI SpellText;
    [SerializeField] TextMeshProUGUI SpellCount;
    [NonSerialized] private XRIDefaultInputActions input;
    private void Start()
    {
        input = PlayerBehaviour.input;
        input.XRILeftInteraction.CastSpell.performed += ctx => SpawnSpell();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void SpawnSpell()
    {
        if (PlayerBehaviour.PlayerSpellCount > 0)
        {
            switch (PlayerBehaviour.PlayerSpell)
            {
                case "Fireball":
                    StartCoroutine(Fireball());
                    break;
                case "Hex Fireball":
                    StartCoroutine(HexFireball());
                    break;
                default:
                    break;
            }
            PlayerBehaviour.PlayerSpellCount--;
        }
        else
        {
            Debug.Log("Нет заклинаний");
        }
    }
    IEnumerator Fireball()
    {
        GameObject currentSpell = Instantiate(fireball, spawnpoint.position, spawnpoint.rotation);
        currentSpell.GetComponent<Rigidbody>().AddForce(spawnpoint.forward*1f, ForceMode.Impulse);
        SpellText.faceColor = new Color(255f, 255f, 255f, 100f);
        SpellCount.faceColor = new Color(255f, 255f, 255f, 100f);
        input.XRILeftInteraction.CastSpell.Disable();
        yield return new WaitForSecondsRealtime(5);
        if (currentSpell != null)
        {
            Destroy(currentSpell);
        }
        SpellText.faceColor = new Color(255f, 255f, 255f, 255f);
        SpellCount.faceColor = new Color(255f, 255f, 255f, 255f);
        input.XRILeftInteraction.CastSpell.Enable();
    }
    IEnumerator HexFireball()
    {
        GameObject currentSpell = Instantiate(hexFireball, spawnpoint.position, spawnpoint.rotation);
        currentSpell.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * 1f, ForceMode.Impulse);
        SpellText.faceColor = new Color(255f, 255f, 255f, 100f);
        SpellCount.faceColor = new Color(255f, 255f, 255f, 100f);
        input.XRILeftInteraction.CastSpell.Disable();
        yield return new WaitForSecondsRealtime(5);
        if (currentSpell != null)
        {
            Destroy(currentSpell);
        }
        SpellText.faceColor = new Color(255f, 255f, 255f, 255f);
        SpellCount.faceColor = new Color(255f, 255f, 255f, 255f);
        input.XRILeftInteraction.CastSpell.Enable();
    }
}
