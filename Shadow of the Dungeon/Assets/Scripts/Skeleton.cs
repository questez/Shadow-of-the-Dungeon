using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform transformPlayer;


    void Update()
    {
        navMeshAgent.destination = transformPlayer.position; 
    }
}
