using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField] GameObject spell;

    [SerializeField] Transform spawnpoint;

    private void Update()
    {
        SpawnSpell();
    }


    private void SpawnSpell()
    {
        Instantiate(spell);
    }
}
