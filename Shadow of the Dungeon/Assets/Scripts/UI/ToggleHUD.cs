using UnityEngine;

public class ToggleHUD : MonoBehaviour
{
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _leftHand;
    void Start()
    {
        if (_canvas != null)
        {
            _canvas.SetActive(true);
        }
    }

    void Update()
    {
        if (_leftHand.transform.eulerAngles.z < -85f && _leftHand.transform.eulerAngles.z > -105f)
        {
            _canvas.SetActive(true);
        }
        else
        {
            _canvas.SetActive(false);
        }
    }
}
