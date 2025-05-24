using System;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] GameObject spell;
    [SerializeField] Transform spawnpoint;
    [NonSerialized] private XRIDefaultInputActions input;
    private void Awake()
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
            Instantiate(spell, spawnpoint);
            PlayerBehaviour.PlayerSpellCount--;
        }
        else
        {
            Debug.Log("Нет заклинаний");
        }
    }
}
