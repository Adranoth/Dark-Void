using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrasLampe : MonoBehaviour
{
    public bool lampeAcquise;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lampeAcquise == true)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
