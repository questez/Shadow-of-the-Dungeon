using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderValue : MonoBehaviour
{
    [SerializeField] Slider _slider;
    public void ChangeValue()
    {
        Debug.Log("Volume: " + _slider.value);
    }
}
