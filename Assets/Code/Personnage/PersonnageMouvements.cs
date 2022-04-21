using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PersonnageMouvements : MonoBehaviour
{
    public Inventaire inventaire;

    public Rigidbody2D personnageRb;
    public float linearDragAuSol = 0f;
    public float linearDragJetpack = 10f;
    public float graviteAuSol = 15f;
    public float graviteJetpack = 0f;
    public Animator personnage;
    public Animator jetpack;

    public bool faceADroite = true;

    public float vitesseMax = 20;
    public float vitesse = 18;
    public float move;
    public float moveY;

    public float dureeMaxDeSaut = 0.3f;
    public float forceDeSaut = 30;
    float tempsDeSaut;
    bool enSaut;
    bool auSol = true;

    bool jetpackActive = false;
    public float jetpackCD = 5f;
    public float essence = 1;
    public float essenceMax ;
    bool jetpackEnCD = false;
    public GameObject lumiere1;
    public GameObject lumiere2;
    public GameObject lumiere3;
    public GameObject jetpackAudio;
    public GameObject feu;

    AudioSource audiosource;
    public AudioClip pas;
    public AudioClip saut;
    public AudioClip atterissage;


    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        essence = 0;
    }

    void FixedUpdate()
    {
        Direction();
    }

    private void Update()
    {
        Saut();
        Jetpack();
        if (jetpackActive == false)
        {
            essence += Time.deltaTime;
            if (essence > 3.33)
            {
                lumiere3.SetActive(true);
                if (essence > 6.66)
                {
                    lumiere2.SetActive(true);
                    if (essence > essenceMax)
                    {
                        essence = essenceMax;
                        lumiere1.SetActive(true);
                    }
                }
            }
        }
        else
        {
            essence -= Time.deltaTime;
            if (essence < 6.66)
            {
                lumiere1.SetActive(false);
                if (essence < 3.33)
                {
                    lumiere2.SetActive(false);
                    if (essence < 0)
                    {
                        essence = 0;
                        lumiere3.SetActive(false);
                        feu.SetActive(false);
                        jetpackActive = false;
                        jetpackEnCD = true;
                        personnageRb.drag = linearDragAuSol;
                        personnageRb.gravityScale = graviteAuSol;
                        jetpack.SetBool("EstAllume", false);
                        jetpackAudio.GetComponent<AudioSource>().Stop();
                    }
                }
            }
        }
    }

    private void Direction()
    {
        move = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        personnage.SetFloat("Speed2", Mathf.Abs(move));

        if (faceADroite == true)
        {
            personnage.SetFloat("Speed", move);
        }
        else
        {
            personnage.SetFloat("Speed", (move * -1));
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (difference.x > 0f && !faceADroite)
        {
            Flip();
        }

        if (difference.x < 0f && faceADroite)
        {
            Flip();
        }

        if (!jetpackActive)
        {
            personnageRb.velocity = new Vector2(vitesse * move, personnageRb.velocity.y);
        }else
        {
            personnageRb.velocity = new Vector2(vitesse * move, vitesse * moveY);
        }
    }

    private void Flip()
    {
        faceADroite = !faceADroite;

        transform.Rotate(0f, 180f, 0f);
    }
    /*
    private void Jetpack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !auSol && !enSaut && inventaire.jetpackAcquis && !jetpackEnCD)
        {
            enSaut = false;
            tempsDeJetpack = 0;
            jetpackActive = true;
            personnageRb.drag = linearDragJetpack;
            personnageRb.gravityScale = graviteJetpack;
            jetpack.SetBool("EstAllume", true);
        }
         if (jetpackActive)
         {
            tempsDeJetpack += Time.deltaTime;
         }
        
        if ((Input.GetKeyUp(KeyCode.Space) && tempsDeJetpack > dureeMaxDeJetpack && !jetpackEnCD && jetpackActive))
        {
            jetpackActive = false;
            jetpackEnCD = true;
            tempsDeJetpackCD = 0;
            personnageRb.drag = linearDragAuSol;
            personnageRb.gravityScale = graviteAuSol;
            jetpack.SetBool("EstAllume", false);
        }
        if (jetpackEnCD)
        {
            tempsDeJetpackCD += Time.deltaTime;
        }
        if (tempsDeJetpack > jetpackCD)
        {
            jetpackEnCD = false;
        }
        if (essence == essenceMax)
        {
            jetpackEnCD = false;
        }
    }
    */
    
    private void Jetpack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !auSol && !enSaut && inventaire.jetpackAcquis && !jetpackEnCD)
        {
            enSaut = false;
            jetpackActive = true;
            feu.SetActive(true);
            jetpackAudio.GetComponent<AudioSource>().Play();
            personnageRb.drag = linearDragJetpack;
            personnageRb.gravityScale = graviteJetpack;
            jetpack.SetBool("EstAllume", true);
        }

        if ((Input.GetKeyUp(KeyCode.Space) && !jetpackEnCD && jetpackActive))
        {
            jetpackActive = false;
            jetpackAudio.GetComponent<AudioSource>().Stop();
            personnageRb.drag = linearDragAuSol;
            personnageRb.gravityScale = graviteAuSol;
            jetpack.SetBool("EstAllume", false);
            feu.SetActive(false);
        }
        if (essence == essenceMax)
        {
            jetpackEnCD = false;
        }
    }

    private void Saut()
    {
        if (Input.GetKeyDown(KeyCode.Space) && auSol)
        {
            audiosource.PlayOneShot(saut, 1.5f);
            personnage.SetBool("IsJumping", true);
            audiosource.PlayOneShot(saut, 1f);
            enSaut = true;
            tempsDeSaut = 0;
            auSol = false;
        }
        if (enSaut)
        {
            personnageRb.velocity = new Vector2(personnageRb.velocity.x, forceDeSaut);
            tempsDeSaut += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) | tempsDeSaut > dureeMaxDeSaut)
        {
            enSaut = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sol") && auSol == false)
        {
            audiosource.PlayOneShot(atterissage, 2f);
            auSol = true;
            personnage.SetBool("IsJumping", false);
        }
    }

    private void BruitDePas()
    {
        audiosource.PlayOneShot(pas, 1f);
    }
}