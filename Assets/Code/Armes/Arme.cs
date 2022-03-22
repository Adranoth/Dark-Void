using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arme : MonoBehaviour
{
    public Transform sortieDeLaBalle;
    public GameObject ballePrefab;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Tirer();
        }
    }

    void Tirer()
    {
        Instantiate(ballePrefab, sortieDeLaBalle.position, sortieDeLaBalle.rotation);
    }
}

