using System;
using System.Collections;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] GameObject fireball;
    [SerializeField] GameObject lightning;
    [SerializeField] Transform spawnpoint;
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
                case "Lightning":
                    StartCoroutine(Lightning());
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
        input.XRILeftInteraction.CastSpell.Disable();
        yield return new WaitForSecondsRealtime(5);
        if (currentSpell != null)
        {
            Destroy(currentSpell);
        }
        input.XRILeftInteraction.CastSpell.Enable();
    }
    IEnumerator Lightning()
    {
        GameObject currentSpell = Instantiate(lightning, spawnpoint.position, spawnpoint.rotation);
        input.XRILeftInteraction.CastSpell.Disable();
        yield return new WaitForSecondsRealtime(1);
        if (currentSpell != null)
        {
            Destroy(currentSpell);
        }
        yield return new WaitForSecondsRealtime(4);
        input.XRILeftInteraction.CastSpell.Enable();
    }
}
