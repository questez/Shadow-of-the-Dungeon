using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _Target;

    
    private void LateUpdate()
    {
        if (_Target != null)
        {
            transform.position = _Target.position;
            transform.eulerAngles = _Target.eulerAngles;
        }
    }
}
