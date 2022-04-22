using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEnnemis : MonoBehaviour
{
    public Vector3[] enfantsPositions; 

    void Start()
    {

        enfantsPositions = new Vector3[gameObject.transform.childCount];

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            enfantsPositions[i] = gameObject.transform.GetChild(i).gameObject.transform.position;
        }
    }

    public void ResetPosEnnemis()
    {
        int i = 0;

        foreach (Transform enfant in transform)
        {
            enfant.gameObject.SetActive(true);
            enfant.transform.position = enfantsPositions[i];
            i++;
        }
    }
}
