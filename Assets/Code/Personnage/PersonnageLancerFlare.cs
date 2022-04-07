using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageLancerFlare : MonoBehaviour
{
    public Transform sortieDuFlare;
    public GameObject flarePrefab;
    public int nbFlareMax = 6;
    public int nbFlareActuel;
    public Animator animator;

    private void Start()
    {
        nbFlareActuel = nbFlareMax;
    }

    void Update()
    {
        if ((Input.GetButtonDown("Fire2")) && nbFlareActuel > 0)
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
        nbFlareActuel -= 1;
    }
}

