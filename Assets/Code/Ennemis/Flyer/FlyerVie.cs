using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerVie : MonoBehaviour
{
    public int vieMax = 75;
    public int vieActuelle;

    void Awake()
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
