using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public static bool jeuEnPause = false;

    public GameObject menuPauseUI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(jeuEnPause)
            {
                reprendreJeu();
            }
            else
            {
                pause();
            }
        }
    }

    public void reprendreJeu()
    {
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        jeuEnPause = false;
    }

    void pause()
    {
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        jeuEnPause = true;
    }

    public void chargerMenu()
    {

    }

    public void quitterJeu()
    {
        Application.Quit();
    }
}