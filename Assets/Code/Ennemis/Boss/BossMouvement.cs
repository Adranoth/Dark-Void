using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMouvement : MonoBehaviour
{
    public Rigidbody2D bossRB;
    private Vector3 cible1;
    private Vector3 cible2;
    public Transform borne1;
    public Transform borne2;
    public float vitesse = 5f;
    public int degats = 35;
    bool versLaDroite = true;
    bool kbDroite;
    float distanceX;
    float distanceY;

    private void Start()
    {
        cible1 = new Vector3(borne1.position.x, bossRB.position.y, 0);
        cible2 = new Vector3(borne2.position.x, bossRB.position.y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (versLaDroite)
        {
            bossRB.position = Vector2.MoveTowards(transform.position, cible1, vitesse * Time.deltaTime);
        }
        else
        {
            bossRB.position = Vector2.MoveTowards(transform.position, cible2, vitesse * Time.deltaTime);
        }
        distanceX = (GameObject.FindGameObjectWithTag("Joueur").transform.position.x - transform.position.x);
        distanceY = (GameObject.FindGameObjectWithTag("Joueur").transform.position.y - transform.position.y);
        if (distanceX > 0)
        {
            kbDroite = false;
        }
        else
        {
            kbDroite = true;
        }
        if ((Mathf.Abs(distanceX) < 20) && (Mathf.Abs(distanceY) < 5))
        {
            FindObjectOfType<BossClone>().enabled = true;
        }
        else if ((Mathf.Abs(distanceX) > 50))
        {
            FindObjectOfType<BossClone>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoiteMunition"))
        {
            versLaDroite = !versLaDroite;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Joueur")
        {
            PersonnageVie personnageVie = collision.transform.GetComponent<PersonnageVie>();
            personnageVie.PrendreDegats(degats, kbDroite);
        }
    }
}
