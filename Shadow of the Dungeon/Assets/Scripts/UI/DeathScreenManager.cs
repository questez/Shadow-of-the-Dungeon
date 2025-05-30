using TMPro;
using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScore;

    private void Start()
    {
        currentScore.text = FindAnyObjectByType<PlayerBehaviour>().GetCurrentScore().ToString();
    }
}
