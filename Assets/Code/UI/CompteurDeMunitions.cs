using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompteurDeMunitions : MonoBehaviour
{
    public Text nbDeMunitions;
    GameObject personnage;
    // Start is called before the first frame update
    void Start()
    {
        nbDeMunitions = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        nbDeMunitions.text = personnage.GetComponent<PersonnageTirer>().MunitionsActuelles.ToString();
    }
}
