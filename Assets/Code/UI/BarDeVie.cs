using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarDeVie : MonoBehaviour
{
    public Slider slider;

    public void MetVieMax(int vie)
    {
        slider.maxValue = vie;
        slider.value = vie;
    }
    public void MetVie(int vie)
    {
        slider.value = vie;
    }

}
