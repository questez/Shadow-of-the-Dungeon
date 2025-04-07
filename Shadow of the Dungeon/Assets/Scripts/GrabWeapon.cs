using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabWeapon : MonoBehaviour
{
    [SerializeField] GameObject _canvas;

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
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }
    public void OnUnGrab(SelectExitEventArgs args)
    {
        if (_canvas != null)
        {
            _canvas.SetActive(false);
        }
        args.interactableObject.transform.SetParent(null);
    }
}
