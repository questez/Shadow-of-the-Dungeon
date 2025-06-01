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

    [NonSerialized] public static float SoundValue;
    [NonSerialized] public static float MusicValue;    

    public void ChangeValue()
    {
        if (_text.text == "√ромкость Ёффектов" && SoundSource != null)
        {
            Debug.Log("√ромкость Ёффектов: " + _slider.value);
            SoundSource.volume = _slider.value / 100;
            SoundValue = _slider.value;
        }
        if (_text.text == "√ромкость ћузыки" && MusicSource != null)
        {
            Debug.Log("√ромкость ћузыки: " + _slider.value);
            MusicSource.volume = _slider.value / 100;
            MusicValue = _slider.value;
        }
    }
}
