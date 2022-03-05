using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    //    public AudioSource LevelMusic;
    public AudioSource jump;
    public AudioSource death;

   // public bool levelSong = true;
   // public bool deathSong = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void muzikaOf()  //vypne hudbu
    {

        jump.gameObject.SetActive(false);       //vypne pridanu muziku
        death.gameObject.SetActive(false);

    }

    public void muzikaOn()  //zapne hudbu
    {

        jump.gameObject.SetActive(true);    //zapne pridanu hudbu
        death.gameObject.SetActive(true);

    }
    /* public void levelMusic()     //toto nejde
     {

         levelSong = true;
         deathSong = false;
         LevelMusic.Play();

     }

     public void deathSound()
     {

         if (LevelMusic.isPlaying)
             levelSong = false;
         {
             LevelMusic.Stop();
         }

         if(!DeathSong.isPlaying && deathSong == false)
         {
             DeathSong.Play();
             deathSong = true;
         }
     }
 */

}

