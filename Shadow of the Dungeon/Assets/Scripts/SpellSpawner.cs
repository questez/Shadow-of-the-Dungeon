using System;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] GameObject spell;
    [SerializeField] Transform spawnpoint;
    [NonSerialized] private XRIDefaultInputActions input;
    [NonSerialized] private PlayerBehaviour pb;
    private void Awake()
    {
        pb = FindAnyObjectByType<PlayerBehaviour>();
        input = new XRIDefaultInputActions();
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
        if (pb.PlayerSpellCount > 0)
        {
            Instantiate(spell, spawnpoint);
            pb.PlayerSpellCount--;
        }
        else
        {
            Debug.Log("Нет заклинаний");
        }
    }
}
