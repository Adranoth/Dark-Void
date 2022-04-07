using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrasLampe : MonoBehaviour
{
    public Inventaire inventaire;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    void Update()
    {
        if (inventaire.lampeAcquise == true)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
