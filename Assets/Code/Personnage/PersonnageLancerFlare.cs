using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageLancerFlare : MonoBehaviour
{
    public Transform sortieDuFlare;
    public GameObject flarePrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Tirer();
        }
    }

    void Tirer()
    {
        Instantiate(flarePrefab, sortieDuFlare.position, sortieDuFlare.rotation);
    }
}

