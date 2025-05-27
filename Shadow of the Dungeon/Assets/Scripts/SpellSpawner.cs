using System;
using System.Collections;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] GameObject spell;
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
            StartCoroutine(FireBall());
            PlayerBehaviour.PlayerSpellCount--;
        }
        else
        {
            Debug.Log("Нет заклинаний");
        }
    }
    IEnumerator FireBall()
    {
        GameObject currentSpell = Instantiate(spell, spawnpoint.position, spawnpoint.rotation);
        currentSpell.GetComponent<Rigidbody>().AddForce(spawnpoint.forward*1f, ForceMode.Impulse);
        input.Disable();
        yield return new WaitForSecondsRealtime(5);
        if (currentSpell != null)
        {
            Destroy(currentSpell);
        }
        input.Enable();
    }
}
