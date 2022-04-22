using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerVie : MonoBehaviour
{
    public int vieMax = 100;
    public int vieActuelle;
    public GameObject pateAClonePrefab;

    void OnEnable()
    {
        vieActuelle = vieMax;
    }

    public void PrendreDegats(int degats)
    {

        vieActuelle -= degats;

        if (vieActuelle <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(pateAClonePrefab, transform.position, transform.rotation);
        }
    }
}
