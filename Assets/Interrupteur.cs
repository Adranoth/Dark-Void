using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrupteur : MonoBehaviour
{
    public GameObject lumiere1;
    bool allume = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (allume == false)
            {
                lumiere1.SetActive(false);
                allume = true;
            }
            else
            {
                lumiere1.SetActive(true);
                allume = false;
            }
        }
    }
}
