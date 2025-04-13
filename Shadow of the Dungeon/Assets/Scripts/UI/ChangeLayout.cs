using UnityEngine;
using UnityEngine.UI;

public class ChangeLayout : MonoBehaviour
{
    [SerializeField] Toggle _toggle;
    public void ToggleLayout()
    {
        if (_toggle.isOn == true)
        {
            Debug.Log("Left-handed layout enabled");
        }
        else
        {
            Debug.Log("Left-handed layout disabled");
        }
    }
}