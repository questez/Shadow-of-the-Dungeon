using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject mysteryBox;
    [SerializeField] Transform[] spawnpoints;

    public void SpawnBox()
    {
        System.Random rand = new System.Random();
        int index = rand.Next(0, spawnpoints.Length);
        Instantiate(mysteryBox, spawnpoints[index].position, spawnpoints[index].rotation);
    }
}
