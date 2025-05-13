using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderValue : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] Slider _slider;
    [SerializeField] AudioSource _musicSource;
    public void ChangeValue()
    {
        if (_text.text == "Sound Volume")
        {
            Debug.Log("Sound Volume: " + _slider.value);
        }
        else
        {
            Debug.Log("Music Volume: " + _slider.value);
            _musicSource.volume = _slider.value / 100;
        }
    }
}
