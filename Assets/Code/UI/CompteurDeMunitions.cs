using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompteurDeMunitions : MonoBehaviour
{

    public Inventaire inventaire;
    public Text nbDeMunitions;

    void Start()
    {
        nbDeMunitions = GetComponent<Text>();
    }

    void Update()
    {
        nbDeMunitions.text = inventaire.munitionsActuelles.ToString();
    }
}
