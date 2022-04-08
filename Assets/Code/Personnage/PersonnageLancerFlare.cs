using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageLancerFlare : MonoBehaviour
{
    public Inventaire inventaire;

    public Transform sortieDuFlare;
    public GameObject flarePrefab;
    public Animator animator;

    void Update()
    {
        if ((Input.GetButtonDown("Fire2")) && inventaire.nbFlareActuels > 0)
        {
            animator.SetTrigger("Lance");
            Tirer();
        }
        else
        {
            return;
        }
    }

    void Tirer()
    {
        Instantiate(flarePrefab, sortieDuFlare.position, sortieDuFlare.rotation);
        inventaire.nbFlareActuels -= 1;
        inventaire.fusee.text = inventaire.nbFlareActuels.ToString();
    }
}

