using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabWeapon : MonoBehaviour
{
    [SerializeField] Collider weaponCollider;
    [SerializeField] Collider _stonetableCollider;
    [SerializeField] GameObject _canvas;
    public float PlayerDamage; // добавить чтобы с увеличением скорости урон также увеличивался    

   
    public void OnGrab(SelectEnterEventArgs args)
    {
        if (_canvas != null)
        {
            _canvas.SetActive(true);
        }
        if (weaponCollider != null)
        {
            weaponCollider.isTrigger = true;
        }
        if (_stonetableCollider != null)
        {
            _stonetableCollider.attachedRigidbody.isKinematic = false;
            _stonetableCollider.isTrigger = true;
            
            
        }
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }
    public void OnUnGrab(SelectExitEventArgs args)
    {
        
        if (weaponCollider != null)
        {
            weaponCollider.isTrigger = false;
        }
               
        args.interactableObject.transform.SetParent(null);
    }
}
