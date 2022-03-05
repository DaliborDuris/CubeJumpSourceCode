using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public GameObject pauseMenu;
    bool Pause = false;



    private void Update()
    {

        if (Pause == false)
        {
            resumeGame(); 
        }

        else
        {
             pauseGame();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Pause == true)
            {
                Pause = false;
            }

            else
            {
                Pause = true;
            }

        }

        if (Pause == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                RestartGame();
                Pause = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitToMenu();
                Pause = false;
            }
        }

        /* if (Input.GetKeyDown(KeyCode.P))          //stlacenie P
         {
            pauseGame();        //funkcia pauseGame
         }

        if (Input.GetKeyDown(KeyCode.O)) //stlacenie space alebo F, lave tlacitko
        {

                    Time.timeScale = 1f;       // cas 1 hra bezi
                    pauseMenu.SetActive(false);   //neni zapnuty Pause button scena neaktivna

        } */
    }
      

    public void pauseGame()
    {

       Time.timeScale = 0f;    //cas 0 hra je pauznuta
       pauseMenu.SetActive(true);   // je zapnuty pause button
        Pause = true;

    }

    public void resumeGame()
    {
        Time.timeScale = 1f;       // cas 1 hra bezi
        pauseMenu.SetActive(false);//neni zapnuty Pause button scena neaktivna
        Pause = false;
    }

    public void RestartGame()
    {    
        Time.timeScale = 1f;
        pauseMenu.SetActive(false); //scena neaktivna
        Pause = false;
        FindObjectOfType<GameManager>().Reset();   //Reset Zavola funkciu z GameManager reset
        FindObjectOfType<PlayerController>().PauseRestart();
    }

    public void QuitToMenu()
    {

        Time.timeScale = 1f;
        //Application.LoadLevel(mainMenuLevel);       //Nacita scenu Menu
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}