using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogues 
{
    public string nom;

    [TextArea(3, 10)]
    public string[] phrases;

    [TextArea(3, 10)]
    public string[] phrases2;


}
