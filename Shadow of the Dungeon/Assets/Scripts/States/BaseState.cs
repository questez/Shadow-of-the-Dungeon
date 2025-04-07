using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    
}
