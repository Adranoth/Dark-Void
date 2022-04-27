using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerVie : MonoBehaviour
{
    public int vieMax = 100;
    public int vieActuelle;
    public GameObject pateAClonePrefab;
    public GameObject aggro;

    void OnEnable()
    {
        vieActuelle = vieMax;
    }

    public void PrendreDegats(int degats)
    {

        vieActuelle -= degats;

        if (vieActuelle <= 0)
        {
            FindObjectOfType<AudioManager>().enCombatMusique = false;
            FindObjectOfType<AudioManager>().MonstreMort(aggro);
            gameObject.SetActive(false);
            Instantiate(pateAClonePrefab, transform.position, transform.rotation);

        }
    }
}
