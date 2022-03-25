using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageVisee : MonoBehaviour
{
    public int decalage = 0;

    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + decalage);
    }
}
