using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidh;

    public GameObject[] thePlatforms; 
    private int platformSelector;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
   
    void Start()
    {
         platformWidh = thePlatform.GetComponent<BoxCollider2D>().size.x;

        minHeight = transform.position.y;               //min hodnota y
        maxHeight = maxHeightPoint.position.y;       //max hodnota y

       
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);   //random medzera ma nastavenu maximalnu
                                                                                        // a minimalnu hodnotu

            heightChange = transform.position.y + Random.Range(maxHeightChange, - maxHeightChange);  //random vyska platform
                                                                                                //ma nastavenu max vyšku a min vyšku
                                                                                                // nastavenie max prevyšenia
            if(heightChange > maxHeight)                            //aby to nešlo moc vysoko
            {

                heightChange = maxHeight;                           //ak je moc hore rovna sa maximalnej hodnote

            }   else if (heightChange < minHeight)                  //aby to neslo moc dole
            {

                heightChange = minHeight;                           //ak je moc dolu rovna sa minimalnej hodnote

            }

            transform.position = new Vector3(transform.position.x + platformWidh + distanceBetween, heightChange, transform.position.z);

            platformSelector = Random.Range(0, thePlatforms.Length);   //vytvorime subor platforiem od 0 do poctu platforiem
                                                                       //ktore si vlozime v Unity

            Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);   //vyberie platformu
        }
    }
}
