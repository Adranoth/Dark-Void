using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nomDuNPC;
    public TextMeshProUGUI dialogueTexte;
    private Queue<string> phrases;


    void Start()
    {
        phrases = new Queue<string>();
    }

    public void Parler (Dialogues dialogue)
    {
        nomDuNPC.text = dialogue.nom;
        phrases.Clear();

        foreach (string phrase in dialogue.phrases)
        {
            phrases.Enqueue(phrase);
        }

        MontrerProchainePhrase();
        return;
    }

    public void Parler2(Dialogues dialogue)
    {
        nomDuNPC.text = dialogue.nom;
        phrases.Clear();

        foreach (string phrase in dialogue.phrases2)
        {
            phrases.Enqueue(phrase);
        }

        MontrerProchainePhrase();
        return;
    }

    public void MontrerProchainePhrase ()
    {
        if (phrases.Count == 0)
        {
            TerminerConversation();
            return;
        }

        string phrase = phrases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(EcrirePhrase(phrase));
    }

    IEnumerator EcrirePhrase (string phrase)
    {
        dialogueTexte.text = "";
        foreach (char lettre in phrase.ToCharArray())
        {
            dialogueTexte.text += lettre;
            yield return null;
        }
    }

    void TerminerConversation()
    {
        nomDuNPC.text = "";
        dialogueTexte.text = "";
    }
}

