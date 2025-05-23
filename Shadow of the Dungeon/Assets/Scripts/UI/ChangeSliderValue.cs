using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderValue: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Slider _slider;
    [SerializeField] AudioSource SoundSource;
    [SerializeField] AudioSource MusicSource;

    [NonSerialized] public float SoundValue;
    [NonSerialized] public float MusicValue;

    public void ChangeValue()
    {
        if (_text.text == "Sound Volume" && SoundSource != null)
        {
            Debug.Log("SoundVolume: " + _slider.value);
            SoundSource.volume = _slider.value / 100;
            SoundValue = _slider.value;
        }
        else if (_text.text == "Music Volume" && MusicSource != null)
        {
            Debug.Log("MusicVolume: " + _slider.value);
            MusicSource.volume = _slider.value / 100;
            MusicValue = _slider.value;
        }
    }
}
