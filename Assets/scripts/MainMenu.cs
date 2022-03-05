using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space))          //F a space zapnu hru
        {
            PlayGame();     //nacita level
        }

        if (Input.GetKeyDown(KeyCode.Escape))       //stlacenie esc vypne hru
        {

            QuitGame();     //vypne hru

        }

    }

    public void PlayGame()                            //nacita level
    {
        //Application.LoadLevel(playGameLevel);
        UnityEngine.SceneManagement.SceneManager.LoadScene(playGameLevel);
    }


  public void QuitGame()                                //ukonci hru
  {
        Application.Quit();
  }


}
