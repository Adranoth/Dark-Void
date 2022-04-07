using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
