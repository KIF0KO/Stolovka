using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angry : MonoBehaviour
{
    private static Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    static public void AngryPlus(float value)
    {
        slider.value += value;
    }
}
