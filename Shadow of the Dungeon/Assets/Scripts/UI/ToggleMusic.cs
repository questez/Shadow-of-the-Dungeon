using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    [SerializeField] Toggle _toggle;
    public void SwitchMusic()
    {
        if (_toggle.isOn == true)
        {
            Debug.Log("Music enabled");
        }
        else
        {
            Debug.Log("Music disabled");
        }
    }
}