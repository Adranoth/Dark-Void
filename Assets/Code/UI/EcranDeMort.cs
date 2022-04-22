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
    public ResetEnnemis resetEnnemis;

    public GameObject choixRespawn;
    public GameObject choixClone;

    public Button boutonB;
    public Button boutonC;
    public Button boutonD;

    public int pateAClone;
    public GameObject pateACloneJoueurPrefab;

    public bool respawnCheckpoint;
    public Animator animator;


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

        GameObject massePateACLone = Instantiate(pateACloneJoueurPrefab, joueur.transform.position, joueur.transform.rotation);

        switch (classe)
        {
            case 0:
                vieCoef = 1;
                vitesseCoef = 1;
                if(respawnCheckpoint)
                {
                    massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle - 1500;
                    inventaire.pateACloneActuelle = 0;
                    animator.SetBool("Classe B", true);
                    animator.SetBool("Classe C", false);
                    animator.SetBool("Classe D", false);
                    break;
                }
                massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle - 1000;
                inventaire.pateACloneActuelle = 0;
                break;
            case 1:
                vieCoef = 0.75f;
                vitesseCoef = 0.90f;
                if (respawnCheckpoint)
                {
                    massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle - 500;
                    inventaire.pateACloneActuelle = 0;
                    animator.SetBool("Classe B", false);
                    animator.SetBool("Classe C", true);
                    animator.SetBool("Classe D", false);
                }
                massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle;
                inventaire.pateACloneActuelle = 0;
                break;
            case 2:
                vieCoef = 0.25f;
                vitesseCoef = 0.75f;
                massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle;
                inventaire.pateACloneActuelle = 0;
                animator.SetBool("Classe B", false);
                animator.SetBool("Classe C", false);
                animator.SetBool("Classe D", true);
                break;
            default:
                vieCoef = 0.75f;
                vitesseCoef = 0.90f;
                massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle;
                inventaire.pateACloneActuelle = 0;
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

        int vie = (int)((float)personnageVie.vieMax * vieCoef);
        personnageVie.vieActuelle = vie;
        personnageVie.bardevie.MetVie(vie);
        personnageMouvements.vitesse = personnageMouvements.vitesseMax * vitesseCoef;
        personnageVie.estInvincible = false;
        personnageVie.graphiques.color = new Color(1f, 1f, 1f, 1f);
        resetEnnemis.ResetPosEnnemis();
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

        boutonC.interactable = true;
    }

}
