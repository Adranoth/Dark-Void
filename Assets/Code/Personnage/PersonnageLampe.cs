using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageLampe : MonoBehaviour
{
    public GameObject lumiere;
    public bool lampeAcquise = false;
    public bool estAllume = false;
    
    void Start()
    {
        lumiere.SetActive(estAllume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && lampeAcquise)
        {
            LumiereSwitch();
        }
    }

    public void LumiereSwitch()
    {
        estAllume = !estAllume;
        lumiere.SetActive(estAllume);
    }
}
