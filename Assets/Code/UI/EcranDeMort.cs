using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcranDeMort : MonoBehaviour
{
    public GameObject joueur;
    public PersonnageVie personnageVie;

    public void RespawnCheckpoint()
    {
        joueur.transform.position = personnageVie.checkpoint.position;
        personnageVie.vieActuelle = personnageVie.vieMax - 50;
        personnageVie.estInvincible = false;
        personnageVie.graphiques.color = new Color(1f, 1f, 1f, 1f);
    }

    public void RespawnVaisseau()
    {
        joueur.transform.position = personnageVie.vaisseau.position;
        personnageVie.vieActuelle = personnageVie.vieMax;
        personnageVie.estInvincible = false;
        personnageVie.graphiques.color = new Color(1f, 1f, 1f, 1f);
    }
}
