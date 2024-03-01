using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider slider;
    private string newText;
    private float valueToPercent;
    private float roundedValue;

    public void Awake()
    {
        valueToPercent = slider.value * 100;
        roundedValue = Mathf.Round(valueToPercent);
        if (roundedValue == 0)
        {
            newText = string.Format("0 %");
        }
        else
        {
            newText = roundedValue.ToString("#") + " %";
        }
        text.text = newText;
    }

    public void OnValueChanged(float newValue)
    {
        valueToPercent = newValue * 100;
        roundedValue = Mathf.Round(valueToPercent);
        if(roundedValue == 0)
        {
            newText = string.Format("0 %");
        }
        else
        {
            newText = roundedValue.ToString("#") + " %";
        }
        text.text = newText;
    }
}