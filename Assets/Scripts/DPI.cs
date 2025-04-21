using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DPI : MonoBehaviour
{
    public Slider DPISlider;

    private float DPIValue;
    public TextMeshProUGUI DPIValueText;

    void Start()
    {
        // getting the manipulated DPI value from PlayerPrefs and passing values
        DPIValue = PlayerPrefs.GetFloat("DPI");
        DPISlider.value = DPIValue;
        DPIValueText.text = $"{DPIValue}";
    }

    public void AdjustDPI(float value)
    {
        // adjusting DPI based on slider
        DPIValue = value;
        PlayerPrefs.SetFloat("DPI", value);
        DPIValueText.text = $"{value}";
    }
}
