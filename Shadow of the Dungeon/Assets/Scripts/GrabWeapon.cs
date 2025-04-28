using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Collider _collider1;
    [SerializeField] private Collider _collider2;
    public float Damage; // добавить чтобы с увеличением скорости урон также увеличивался
    
    private void Start()
    {
        if (_canvas != null)
        {
            _canvas.SetActive(false);
        }
    }
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
        if (_canvas != null)
        {
            _canvas.SetActive(false);
        }
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
