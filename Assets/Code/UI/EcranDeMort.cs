using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcranDeMort : MonoBehaviour
{
    public Inventaire inventaire;
    public GameObject joueur;
    public PersonnageVie personnageVie;
    public PersonnageMouvements personnageMouvements;

    public GameObject choixRespawn;
    public GameObject choixClone;

    public Button boutonB;
    public Button boutonC;
    public Button boutonD;

    public int pateAClone;

    public bool respawnCheckpoint;

    void OnEnable()
    {
        choixRespawn.SetActive(true);
        choixClone.SetActive(false);
    }

    public void ClasseB()
    {
        Respawn(0);
    }

    public void ClasseC()
    {
        Respawn(1);
    }

    public void ClasseD()
    {
        Respawn(2);
    }

    public void Respawn(int classe)
    {
        float vieCoef;
        float vitesseCoef;

        switch(classe)
        {
            case 0:
                vieCoef = 1;
                vitesseCoef = 1;
                if(respawnCheckpoint)
                {
                    inventaire.pateACloneActuelle -= 1500;
                    break;
                }
                inventaire.pateACloneActuelle -= 1000;
                break;
            case 1:
                vieCoef = 0.75f;
                vitesseCoef = 0.90f;
                if (respawnCheckpoint)
                {
                    inventaire.pateACloneActuelle -= 500;
                }
                break;
            case 2:
                vieCoef = 0.25f;
                vitesseCoef = 0.75f;
                break;
            default:
                vieCoef = 0.75f;
                vitesseCoef = 0.90f;
                break;
        }

        if (respawnCheckpoint)
        {
            joueur.transform.position = personnageVie.checkpoint.position;
        }
        else
        {
            joueur.transform.position = personnageVie.vaisseau.position;
        }

        personnageVie.vieActuelle = (int) ((float) personnageVie.vieMax * vieCoef);
        personnageMouvements.vitesse = personnageMouvements.vitesseMax * vitesseCoef;
        personnageVie.estInvincible = false;
        personnageVie.graphiques.color = new Color(1f, 1f, 1f, 1f);
    }

    public void RespawnCheckpoint()
    {
        respawnCheckpoint = true;

        if(pateAClone < 1500)
        {
            boutonB.interactable = false;
        }else
        {
            boutonB.interactable = true;
        }

        if (pateAClone < 500 && respawnCheckpoint)
        {
            boutonC.interactable = false;
        }else
        {
            boutonC.interactable = true;
        }
    }

    public void RespawnVaisseau()
    {
        respawnCheckpoint = false;

        if (pateAClone < 1000)
        {
            boutonB.interactable = false;
        }
        else
        {
            boutonB.interactable = true;
        }
    }

}
