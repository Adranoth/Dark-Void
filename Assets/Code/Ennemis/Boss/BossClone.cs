using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossClone : MonoBehaviour
{
    public GameObject flyerPrefab;
    public float tempsClone;
    public SpriteRenderer spriteRenderer;
    public Animator cloningPod;
    public Animator decoration;
    public Animator fumee;

    public void CloneFlyer()
    {
        Instantiate(flyerPrefab, transform.position, transform.rotation);
    }

    private void Update()
    {
        tempsClone = tempsClone + Time.deltaTime;
        if (tempsClone >= 5)
        {
            tempsClone = 0;
            StartCoroutine(Spawn());
        }
    }

    public IEnumerator Spawn()
    {
        decoration.SetTrigger("Spawn");
        yield return new WaitForSeconds(0.25f);
        cloningPod.SetTrigger("Spawn");
        yield return new WaitForSeconds(0.75f);
        fumee.SetTrigger("Spawn");
    }
}
