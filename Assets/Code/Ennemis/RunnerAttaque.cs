using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAttaque : MonoBehaviour
{
    public int degats = 10;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Joueur"))
        {
            PersonnageVie personnageVie = collision.transform.GetComponent<PersonnageVie>();
            personnageVie.PrendreDegats(degats);
        }
    }
}
