using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonnageTirer : MonoBehaviour
{
    public Transform sortieDeLaBalle;
    public GameObject ballePrefab;
    public int MunitionsMax = 60;
    public int MunitionsActuelles;
    public TextMeshProUGUI Compteur;
    public AudioSource tirer;
    public AudioSource PlusDeMunitions;

    private void Start()
    {
        MunitionsActuelles = MunitionsMax;
        Compteur.text = MunitionsActuelles.ToString();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Tirer();
        }
    }

    void Tirer()
    {
        if (MunitionsActuelles == 0)
        {
            PlusDeMunitions.Play();
        }
        else
        {
            Instantiate(ballePrefab, sortieDeLaBalle.position, sortieDeLaBalle.rotation);
            MunitionsActuelles -= 1;
            Compteur.text = MunitionsActuelles.ToString();
            tirer.Play();
        }
    }
}

