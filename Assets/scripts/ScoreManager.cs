using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
            if (scoreIncreasing)
            { 
            scoreCount += pointsPerSecond * Time.deltaTime;     //pridava score podla času
            }                                                   //sčita a prenasoby hodnoty
        if(scoreCount > hiScoreCount)       //ak je score väčšie ako Hiscore
        {
            hiScoreCount = scoreCount;  //hi score = počitaniu skore        
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);    
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);      //vypisuje score
        highScoreText.text = "High score: " + Mathf.Round (hiScoreCount);   //vypisuje Hiscore

    }
}
