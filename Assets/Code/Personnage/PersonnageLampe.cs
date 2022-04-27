using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageLampe : MonoBehaviour
{
    public Inventaire inventaire;

    public GameObject lumiere;
    public GameObject collision;
    public bool estAllume = false;
    public bool dejaAllume = false;
    
    void Start()
    {
        lumiere.SetActive(estAllume);
        collision.SetActive(estAllume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && inventaire.lampeAcquise)
        {
            LumiereSwitch();
        }
    }

    public void LumiereSwitch()
    {
        estAllume = !estAllume;
        lumiere.SetActive(estAllume);
        collision.SetActive(estAllume);
        dejaAllume = !dejaAllume;
    }
}
