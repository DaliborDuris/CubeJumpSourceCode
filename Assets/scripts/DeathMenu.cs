using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))                //ak stlacime R
        {
            RestartGame();               //načitanie Levela odzaciatku cislo je podla usporiadania scen v  Built settings
        }

        if (Input.GetKeyDown(KeyCode.Escape))       //stlacenie ESC
        {

            QuitToMenu();       //nacita scenu menu
        }
    }

    public void RestartGame()
    {

        FindObjectOfType<GameManager>().Reset();   //Reset Zavola funkciu z GameManager reset
      
    }

    public void QuitToMenu()
    {
            
         //Application.LoadLevel(mainMenuLevel);       //Nacita scenu Menu     
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
