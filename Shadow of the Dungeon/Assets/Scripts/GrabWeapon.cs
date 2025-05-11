using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabWeapon : MonoBehaviour
{
    [SerializeField] Collider _collider1;
    [SerializeField] Collider _collider2;
    [SerializeField] GameObject _canvas;
    public float PlayerDamage; // добавить чтобы с увеличением скорости урон также увеличивался    

   
    public void OnGrab(SelectEnterEventArgs args)
    {
        if (_canvas != null)
        {
            _canvas.SetActive(true);
        }
        if (_collider1 != null)
        {
            _collider1.isTrigger = true;
        }
        if (_collider2 != null)
        {
            _collider2.isTrigger = true;
        }
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }
    public void OnUnGrab(SelectExitEventArgs args)
    {
        
        if (_collider1 != null)
        {
            _collider1.isTrigger = false;
        }
        if (_collider2 != null)
        {
            _collider2.isTrigger = false;
        }        
        args.interactableObject.transform.SetParent(null);
    }
}
