using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageBrasRotation : MonoBehaviour
{
    public Transform personnage;
    bool faceADroite = true;
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - personnage.position;

        if (difference.x > 0f && !faceADroite)
        {
            Flip();
        }

        if (difference.x < 0f && faceADroite)
        {
            Flip();
        }
    }

    private void Flip()
    {
        faceADroite = !faceADroite;

        transform.Rotate(180f, 0f, 0f);
    }
}
