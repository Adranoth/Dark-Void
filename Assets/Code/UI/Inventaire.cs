using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventaire : MonoBehaviour
{
    //Gestion des flares
    public int nbFlareMax = 6;
    public int nbFlareActuels;

    //Gestion des munitions
    public int munitionsMax = 60;
    public int munitionsActuelle;
    public int chargeursMax = 4;
    public int chargeursActuels;

    //Gestion des medikits
    public int nbMediKitsMax = 2;
    public int nbMediKitsActuels;

    //Jetpack
    public bool jetpackAcquis = false;

    //Lampe
    public bool lampeAcquise = false;

    //Gestion de la pate a clone
    public int pateACloneMax = 9999;
    public int pateACloneActuelle;

    //Texte pour l'inventaire
    public TextMeshProUGUI fusee;
    public TextMeshProUGUI premierSoin;
    public TextMeshProUGUI chargeur;
    public TextMeshProUGUI pateAClone;
    public GameObject inventaire;

    //Gestion des Audiologs
    public bool audio1;
    public bool audio2;
    public bool audio3;

    //Allumer/Éteindre inventaire
    bool InventaireAllume;
    public GameObject lumiere;
    public GameObject personnage;
    public PersonnageMouvements direction;
    private void Awake()
    {
        //Inventaire de Départ
        nbFlareActuels = nbFlareMax;
        nbMediKitsActuels = nbMediKitsMax;
        munitionsActuelle = munitionsMax;
        chargeursActuels = chargeursMax;

        //Gestion du texte pour l'inventaire
        fusee.text = nbFlareActuels.ToString();
        premierSoin.text = nbMediKitsActuels.ToString();
        chargeur.text = chargeursActuels.ToString();
        pateAClone.text = pateACloneActuelle.ToString();
    }

    //Allumer l'inventaire allume une lumière et empêche le joueur de bouger et tirer jusqu'à ce qu'il referme l'inventaire
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventaireAllume == false)
            {
                inventaire.SetActive(true);
                lumiere.SetActive(true);
                personnage.GetComponent<PersonnageMouvements>().enabled = false;
                personnage.GetComponent<PersonnageTirer>().enabled = false;
                personnage.GetComponent<PersonnageLancerFlare>().enabled = false;
                InventaireAllume = true;
                if (direction.faceADroite == false)
                {
                    personnage.transform.Rotate(0f, 180f, 0f);
                    direction.faceADroite = true;
                }
            }
            else
            {
                inventaire.SetActive(false);
                lumiere.SetActive(false);
                personnage.GetComponent<PersonnageMouvements>().enabled = true;
                personnage.GetComponent<PersonnageTirer>().enabled = true;
                personnage.GetComponent<PersonnageLancerFlare>().enabled = true;
                InventaireAllume = false;
            }
        }
    }
}
