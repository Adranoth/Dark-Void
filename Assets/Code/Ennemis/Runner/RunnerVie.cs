using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerVie : MonoBehaviour
{
    public int vieMax = 100;
    public int vieActuelle;
    public GameObject pateAClonePrefab;

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
            Instantiate(pateAClonePrefab, transform.position, transform.rotation);
        }
    }
}
