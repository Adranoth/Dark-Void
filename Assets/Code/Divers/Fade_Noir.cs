using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_Noir : MonoBehaviour
{
    public GameObject carreNoir;

    public IEnumerator FadeNoir(bool fade = true, int fadespeed = 5)
    {
        Color couleur = carreNoir.GetComponent<Image>().color;
        float fadeAmount;
        if (fade)
        {
            while (carreNoir.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = couleur.a + (fadespeed * Time.deltaTime);
                couleur = new Color(couleur.r, couleur.g, couleur.b, fadeAmount);
                carreNoir.GetComponent<Image>().color = couleur;
                yield return null;
            }
        }
        else
        {
            while (carreNoir.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = couleur.a - (fadespeed * Time.deltaTime);
                couleur = new Color(couleur.r, couleur.g, couleur.b, fadeAmount);
                carreNoir.GetComponent<Image>().color = couleur;
                yield return null;
            }
        }
    }
}
