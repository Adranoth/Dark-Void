using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerVie : MonoBehaviour
{

    public int vieMax = 100;
    public int vieActuelle;

    void Start()
    {
        vieActuelle = vieMax;
    }

    public void PrendreDegats(int degats)
    {

        vieActuelle -= degats;

        if (vieActuelle <= 0)
        {
            Destroy(gameObject);
        }
    }
}
