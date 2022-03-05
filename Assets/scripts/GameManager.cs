using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    private PlatformDestruction[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

    public BackRepet theBackground;

    public GameObject Player;
   // public AudioSource LevelSong;


    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
        theBackground = FindObjectOfType<BackRepet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);  //setko umre

        theDeathScreen.gameObject.SetActive(true);      //vybehne death menu
        theBackground.speed = 0f;
        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        theBackground.speed = 0.1f;
        // LevelSong.Play();
        platformList = FindObjectsOfType<PlatformDestruction>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

    }

    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestruction>();
        for(int i=0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/


}
