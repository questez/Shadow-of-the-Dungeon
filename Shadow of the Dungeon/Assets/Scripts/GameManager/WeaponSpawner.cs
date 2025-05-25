using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Swords;
    [SerializeField] Transform spawnPoint;

    private void Start()
    {
        Instantiate(Swords[PlayerBehaviour.EquippedSwordIndex], spawnPoint.position, spawnPoint.rotation);
    }
}

