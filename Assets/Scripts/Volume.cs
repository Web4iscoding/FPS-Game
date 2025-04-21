using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider;

    private float volumeValue;
    public TextMeshProUGUI volumeValueText;

    void Start()
    {
        // getting the manipulated volume value from PlayerPrefs and passing values
        volumeValue = PlayerPrefs.GetFloat("Volume");
        AdjustVolume(volumeValue);
        volumeSlider.value = volumeValue;
        volumeValueText.text = $"{volumeValue}";
    }

    public void AdjustVolume(float value)
    {
        // adjusting volume based on slider
        PlayerPrefs.SetFloat("Volume", value);
        AudioListener.volume = value;
        volumeValueText.text = $"{value}";
    }
}
