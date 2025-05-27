using System;
using System.Collections;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] GameObject spell;
    [NonSerialized] private Transform spawnpoint;
    [NonSerialized] private XRIDefaultInputActions input;
    [NonSerialized] private Rigidbody rb;
    private void Start()
    {
        spawnpoint = gameObject.transform;
        rb = spell.GetComponent<Rigidbody>();
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
        Instantiate(spell, spawnpoint.position + new Vector3(0f, 0f, 1f), spawnpoint.rotation);
        rb.AddForce(spawnpoint.forward*5f, ForceMode.Acceleration);
        input.Disable();
        yield return new WaitForSecondsRealtime(5);
        input.Enable();
    }
}
