using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloningPod : MonoBehaviour
{
    bool interaction;
    public ResetEnnemis resetEnnemis;
    public Inventaire inventaire;
    public PersonnageVie personnageVie;
    public PersonnageTirer personnageTirer;
    public PersonnageMouvements personnageMouvements;
    public GameObject tete;
    public GameObject brasDroit;
    public GameObject brasGauche;
    public GameObject jetpack;
    public GameObject choixClone;
    public GameObject changerClasse;
    public GameObject UICloningPod;
    public GameObject personnage;
    public GameObject UIInfo;
    public Button boutonB;
    public Button boutonC;
    public Button boutonD;
    public float classeB;
    public float classeC;
    public bool cave;
    bool menu;
    public Animator animator;
    public Animator bras;
    public GameObject[] animators;
    public Sprite[] listeTete;


    private void Start()
    {
        animators = GameObject.FindGameObjectsWithTag("Checkpoint");
        animator.keepAnimatorControllerStateOnDisable = false;
        bras.keepAnimatorControllerStateOnDisable = false;
    }

    void Update()
    {
        if (interaction == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UICloningPod.SetActive(true);
                menu = true;
                changerClasse.SetActive(true);
                resetEnnemis.ResetPosEnnemis();
                personnageVie.vieActuelle = personnageVie.vieMax;
                personnageVie.bardevie.MetVieMax(personnageVie.vieMax);
                personnageVie.bardevie.MetVie(personnageVie.vieActuelle);
                inventaire.Reset();
                personnageTirer.CompteurMun.text = inventaire.munitionsActuelle.ToString();
                personnage.SetActive(false);
                personnageVie.checkpoint = gameObject;
                foreach (GameObject anim in animators)
                {
                    anim.GetComponent<Animator>().SetTrigger("Respawn");
                }
            }
        }
        if (menu == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                choixClone.SetActive(false);
                UIInfo.SetActive(true);
                foreach (GameObject anim in animators)
                {
                    anim.GetComponent<Animator>().SetTrigger("Respawn");
                }
                FindObjectOfType<AudioManager>().Play("respawn");
                menu = false;
                changerClasse.SetActive(false);
                personnage.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            interaction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            interaction = false;
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

        switch (classe)
        {
            case 0:
                personnageVie.vieMax = 140;
                personnageMouvements.vitesseMax = 20;
                if (personnageMouvements.vaisseau == false)
                {
                    inventaire.pateACloneActuelle -= 1500;
                }
                else
                {
                    inventaire.pateACloneActuelle -= 1000;
                }
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
                break;
            case 1:
                personnageVie.vieMax = 100;
                personnageMouvements.vitesseMax = 18;
                if (personnageMouvements.vaisseau == false)
                {
                    inventaire.pateACloneActuelle -= 500;
                }
                else
                {
                    return;
                }
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
                break;
            case 2:
                personnageVie.vieMax = 60;
                personnageMouvements.vitesseMax = 18;
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
                break;
        }
        personnageVie.vieActuelle = personnageVie.vieMax;
        personnageVie.bardevie.MetVieMax(personnageVie.vieMax);
        personnageVie.bardevie.MetVie(personnageVie.vieActuelle);
        personnageMouvements.vitesse = personnageMouvements.vitesseMax;
        inventaire.Reset();
        personnageTirer.CompteurMun.text = inventaire.munitionsActuelle.ToString();
        personnageVie.estInvincible = false;
        personnage.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        tete.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        brasDroit.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        brasGauche.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        FindObjectOfType<AudioManager>().Stop("Low-health");
        foreach(GameObject anim in animators)
                {
            anim.GetComponent<Animator>().SetTrigger("Respawn");
        }
        FindObjectOfType<AudioManager>().Play("respawn");
    }

    public void cloningPod()
    {
        UIInfo.SetActive(false);
        choixClone.SetActive(true);
        if (inventaire.pateACloneActuelle < classeB)
        {
            boutonB.interactable = false;
        }
        else
        {
            boutonB.interactable = true;
        }

        if (inventaire.pateACloneActuelle < classeC)
        {
            boutonC.interactable = false;
        }
        else
        {
            boutonC.interactable = true;
        }
        if (cave == true)
        {
            personnageVie.cave = true;
        }
        else
        {
            personnageVie.cave = false;
        }
    }

    public void Mort()
    {
        personnage.GetComponent<SpriteRenderer>().enabled = false;
        personnage.GetComponent<PersonnageMouvements>().enabled = false;
        personnage.GetComponent<PersonnageTirer>().enabled = false;
        personnage.GetComponent<PersonnageLancerFlare>().enabled = false;
        personnage.GetComponent<PersonnageLampe>().enabled = false;
        personnage.GetComponent<OuvrirInventaire>().enabled = false;
        personnage.GetComponent<PersonnageInteraction>().enabled = false;
        personnage.GetComponent<PersonnageInteraction>().texte.GetComponent<SpriteRenderer>().enabled = false;
        personnage.GetComponent<AudioSource>().enabled = false;
        tete.GetComponent<SpriteRenderer>().enabled = false;
        brasDroit.SetActive(false);
        brasGauche.GetComponent<SpriteRenderer>().enabled = false;
        jetpack.SetActive(false);
    }

    public void Vie()
    {
        personnage.GetComponent<SpriteRenderer>().enabled = true;
        personnage.GetComponent<PersonnageMouvements>().enabled = true;
        personnage.GetComponent<PersonnageTirer>().enabled = true;
        personnage.GetComponent<PersonnageLancerFlare>().enabled = true;
        personnage.GetComponent<PersonnageLampe>().enabled = true;
        personnage.GetComponent<OuvrirInventaire>().enabled = true;
        personnage.GetComponent<PersonnageInteraction>().enabled = true;
        personnage.GetComponent<PersonnageInteraction>().texte.GetComponent<SpriteRenderer>().enabled = true;
        personnage.GetComponent<AudioSource>().enabled = true;
        tete.GetComponent<SpriteRenderer>().enabled = true;
        brasGauche.GetComponent<SpriteRenderer>().enabled = true;
        brasDroit.SetActive(true);
        jetpack.SetActive(true);
    }
}
