using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetParallax : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 dernierePosCamera;
    private Vector3 deltaMovement;
    private Sprite sprite;
    private Texture2D texture;
    private float textureUnitSizeX;
    private float textureUnitSizeY;
    //Les différentes layers ont besoin d'un effet parallax différents, plus le chiffre est grand, moin l'objet aura l'air de bouger
    [SerializeField]
    private Vector2 effetParallax;
    public bool infiniHorizontal;
    public bool infiniVertical;
    // Start is called before the first frame update
    void Start()
    {
        //On prend la position de la camera
        cameraTransform = Camera.main.transform;
        dernierePosCamera = cameraTransform.position;
        sprite = GetComponent<SpriteRenderer>().sprite;
        texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Après que la camera bouge, on fait bouger le décor avec
        deltaMovement = cameraTransform.position - dernierePosCamera;
        transform.position += new Vector3(deltaMovement.x * effetParallax.x, deltaMovement.y * effetParallax.y);
        dernierePosCamera = cameraTransform.position;

        if (infiniHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) > +textureUnitSizeX)
            {
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
            }
        }
        if (infiniVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) > +textureUnitSizeY)
            {
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);
            }
        }
    }
}
