using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class NPC : MonoBehaviour
{
    public Dialogues dialogue;
    private bool interaction;
    private bool enConversation;
    private bool dejaParler;
    public Animator animator;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().Parler(dialogue);
    }

    private void Update()
    {
        if (interaction == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (enConversation == false && dejaParler == false)
                {
                    animator.SetBool("Parler", true);
                    TriggerDialogue();
                    enConversation = true;
                    dejaParler = true;
                }
                else
                {
                    FindObjectOfType<DialogueManager>().MontrerProchainePhrase();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            interaction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Joueur"))
        {
            interaction = false;
        }
    }
}
