using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcranDeMort : MonoBehaviour
{
    public Inventaire inventaire;
    public GameObject joueur;
    public GameObject tete;
    public GameObject brasDroit;
    public GameObject brasGauche;
    public PersonnageVie personnageVie;
    public PersonnageMouvements personnageMouvements;
    public PersonnageTirer personnageTirer;
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
    public Animator bras;
    public GameObject[] animators;
    public Sprite[] listeTete;
    public CloningPod cloningPod;

    void OnEnable()
    {
        choixRespawn.SetActive(true);
        choixClone.SetActive(false);
        animators = GameObject.FindGameObjectsWithTag("Checkpoint");
        foreach (GameObject anim in animators)
        {
            anim.GetComponent<Animator>().SetTrigger("Respawn");
        }
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

        GameObject massePateACLone = Instantiate(pateACloneJoueurPrefab, joueur.transform.position, joueur.transform.rotation);

        switch (classe)
        {
            case 0:
                personnageVie.vieMax = 140;
                personnageMouvements.vitesseMax = 20;
                if (respawnCheckpoint)
                {
                    massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle - 1500;
                    inventaire.pateACloneActuelle = 0;
                    animator.SetBool("Classe B", true);
                    animator.SetBool("Classe C", false);
                    animator.SetBool("Classe D", false);
                    bras.SetBool("ClasseB", true);
                    bras.SetBool("ClasseC", false);
                    bras.SetBool("ClasseD", false);
                    personnageTirer.classeB = true;
                    personnageTirer.classeC = false;
                    personnageTirer.classeD = false;
                    inventaire.munitionsMax = 80;
                    inventaire.chargeursMax = 4;
                    tete.GetComponent<SpriteRenderer>().sprite = listeTete[0];
                }
                else
                {
                    animator.SetBool("Classe B", true);
                    animator.SetBool("Classe C", false);
                    animator.SetBool("Classe D", false);
                    bras.SetBool("ClasseB", true);
                    bras.SetBool("ClasseC", false);
                    bras.SetBool("ClasseD", false);
                    personnageTirer.classeB = true;
                    personnageTirer.classeC = false;
                    personnageTirer.classeD = false;
                    inventaire.munitionsMax = 80;
                    inventaire.chargeursMax = 4;
                    tete.GetComponent<SpriteRenderer>().sprite = listeTete[0];
                    massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle - 1000;
                    inventaire.pateACloneActuelle = 0;
                }
                break;

            case 1:
                personnageVie.vieMax = 100;
                personnageMouvements.vitesseMax = 18;
                if (respawnCheckpoint)
                {
                    massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle - 500;
                    inventaire.pateACloneActuelle = 0;
                    animator.SetBool("Classe B", false);
                    animator.SetBool("Classe C", true);
                    animator.SetBool("Classe D", false);
                    bras.SetBool("ClasseB", false);
                    bras.SetBool("ClasseC", true);
                    bras.SetBool("ClasseD", false);
                    personnageTirer.classeB = false;
                    personnageTirer.classeC = true;
                    personnageTirer.classeD = false;
                    inventaire.munitionsMax = 60;
                    inventaire.chargeursMax = 4;
                    tete.GetComponent<SpriteRenderer>().sprite = listeTete[1];
                }
                else
                {
                    animator.SetBool("Classe B", false);
                    animator.SetBool("Classe C", true);
                    animator.SetBool("Classe D", false);
                    bras.SetBool("ClasseB", false);
                    bras.SetBool("ClasseC", true);
                    bras.SetBool("ClasseD", false);
                    personnageTirer.classeB = false;
                    personnageTirer.classeC = true;
                    personnageTirer.classeD = false;
                    inventaire.munitionsMax = 60;
                    inventaire.chargeursMax = 4;
                    tete.GetComponent<SpriteRenderer>().sprite = listeTete[1];
                    massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle;
                    inventaire.pateACloneActuelle = 0;
                    break;
                }
                break;

            case 2:
                personnageVie.vieMax = 60;
                personnageMouvements.vitesseMax = 18;
                massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle;
                inventaire.pateACloneActuelle = 0;
                animator.SetBool("Classe B", false);
                animator.SetBool("Classe C", false);
                animator.SetBool("Classe D", true);
                bras.SetBool("ClasseB", false);
                bras.SetBool("ClasseC", false);
                bras.SetBool("ClasseD", true);
                personnageTirer.classeB = false;
                personnageTirer.classeC = false;
                personnageTirer.classeD = true;
                inventaire.munitionsMax = 15;
                inventaire.chargeursMax = 12;
                tete.GetComponent<SpriteRenderer>().sprite = listeTete[2];
                break;
            default:
                personnageVie.vieMax = 100;
                personnageMouvements.vitesseMax = 18;
                massePateACLone.GetComponent<PateACloneJoueur>().valeur = inventaire.pateACloneActuelle;
                inventaire.pateACloneActuelle = 0;
                break;
        }
        if (respawnCheckpoint)
        {
            joueur.transform.position = personnageVie.checkpoint.transform.position;
        }
        else
        {
            joueur.transform.position = personnageVie.vaisseau.transform.position;
        }
        personnageVie.vieActuelle = personnageVie.vieMax;
        personnageVie.bardevie.MetVieMax(personnageVie.vieMax);
        personnageVie.bardevie.MetVie(personnageVie.vieActuelle);
        personnageMouvements.vitesse = personnageMouvements.vitesseMax;
        inventaire.Reset();
        personnageTirer.CompteurMun.text = inventaire.munitionsActuelle.ToString();
        personnageVie.estInvincible = false;
        joueur.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        tete.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        brasDroit.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        brasGauche.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        resetEnnemis.ResetPosEnnemis();
        FindObjectOfType<AudioManager>().Play("respawn");
        foreach (GameObject anim in animators)
        {
            anim.GetComponent<Animator>().SetTrigger("Respawn");
        }
    }

    public void RespawnCheckpoint()
    {
        respawnCheckpoint = true;
        choixClone.SetActive(true);

        if (pateAClone < 1500)
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
        choixClone.SetActive(true);

    }
}
