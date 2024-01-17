using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    public TextMeshProUGUI numberText;

    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        setNumberText(slider.value);
    }
    public void setNumberText(float val)
    {
        numberText.text = val.ToString();
    }
}
