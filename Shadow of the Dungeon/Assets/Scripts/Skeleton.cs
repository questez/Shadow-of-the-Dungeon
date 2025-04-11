using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform transformPlayer;


    private void Update()
    {
        navMeshAgent.destination = transformPlayer.position; 
    }
}
