using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarDeVie : MonoBehaviour
{
    public Slider slider;
    public GameObject barDeVie;
    public GameObject fusil;
    public TextMeshProUGUI munition;

    public void MetVieMax(int vie)
    {
        slider.maxValue = vie;
        slider.value = vie;
    }
    public void MetVie(int vie)
    {
        slider.value = vie;
    }
    public IEnumerator FadeOut(bool fade = true, int fadespeed = 5)
    {
        Color couleur = barDeVie.GetComponent<Image>().color;
        Color couleur2 = fusil.GetComponent<Image>().color;
        Color couleur3 = munition.color;
        float fadeAmount;
        float fadeAmount2;
        float fadeAmount3;
        if (fade)
        {
            while (barDeVie.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = couleur.a + (fadespeed * Time.deltaTime);
                fadeAmount2 = couleur2.a + (fadespeed * Time.deltaTime);
                fadeAmount3 = couleur3.a + (fadespeed * Time.deltaTime);
                couleur = new Color(couleur.r, couleur.g, couleur.b, fadeAmount);
                barDeVie.GetComponent<Image>().color = couleur;
                couleur2 = new Color(couleur2.r, couleur2.g, couleur2.b, fadeAmount2);
                fusil.GetComponent<Image>().color = couleur2;
                couleur3 = new Color(couleur3.r, couleur3.g, couleur3.b, fadeAmount3);
                munition.color = couleur3;
                yield return null;
            }
        }
        else
        {
            while (barDeVie.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = couleur.a - (fadespeed * Time.deltaTime);
                fadeAmount2 = couleur2.a - (fadespeed * Time.deltaTime);
                fadeAmount3 = couleur3.a - (fadespeed * Time.deltaTime);
                couleur = new Color(couleur.r, couleur.g, couleur.b, fadeAmount);
                barDeVie.GetComponent<Image>().color = couleur;
                couleur2 = new Color(couleur2.r, couleur2.g, couleur2.b, fadeAmount2);
                fusil.GetComponent<Image>().color = couleur2;
                couleur3 = new Color(couleur3.r, couleur3.g, couleur3.b, fadeAmount3);
                munition.color = couleur3;
                yield return null;
            }
        }
    }
}
