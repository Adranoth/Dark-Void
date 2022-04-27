using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvrirInventaire : MonoBehaviour
{
    bool InventaireAllume;
    public GameObject lumiere;
    public GameObject personnage;
    public PersonnageMouvements direction;
    public GameObject inventaire;

    // Update is called once per frame
    void Update()
    {
        if (!MenuPause.jeuEnPause)
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
}
