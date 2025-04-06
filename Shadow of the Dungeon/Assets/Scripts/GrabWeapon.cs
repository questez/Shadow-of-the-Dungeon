using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabWeapon : MonoBehaviour
{
    [SerializeField] GameObject _canvas;

    public void OnGrab(SelectEnterEventArgs args)
    {
        _canvas.SetActive(true);
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }
    public void OnUnGrab(SelectExitEventArgs args)
    {
        _canvas.SetActive(false);
        args.interactableObject.transform.SetParent(null);
    }
}
