using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;
    public float jumpForce;

    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool noJumping;
    private bool doubleJump;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    //private Collider2D myCollider;
    private Animator myAnimator;
    public GameManager theGameManager;

    public AudioSource DeathSound;
    public AudioSource jumpSound;

    public PauseMenu theRestart;
    //public AudioSource stopPlay;


    // Start is called before the first frame update
    void Start()                                        //vlastnosti na začiatku
    {
        myRigidbody = GetComponent<Rigidbody2D>();      //ridžid boooooooody

        // myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();  //animacie getne

        jumpTimeCounter = jumpTime;         //proste veci co ma na zaciatku

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;

        speedMilestoneCountStore = speedMilestoneCount;

        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        noJumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); stary kod čeknutia či je hrač na zemi

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);   //kod zistuje či je hrač na zemi

        if (transform.position.x > speedMilestoneCount)      //automatický pohyb  hrača
        {                                                   //zrýchlovanie hrača
            speedMilestoneCount += speedIncreaseMilestone; // spočita hodnoty zrychlovania 

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier; // prenasobí hodnoty zrychlovania

            moveSpeed = moveSpeed * speedMultiplier;        //rychllosť = prenasobenej hodnote rychlosti a zrýchlenia
        }                                                                       

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y); 

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))          //ovladanie Space , klavesa F, 
        {

            if (grounded)       //ak je naš hrač na zemi tak vyskoči
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);     //jumpForce je hodnota sily vyskočenia 
                noJumping = false;              // hrač neskače
                jumpSound.Play();     
            }

            if (!grounded && doubleJump)    //ak hrač nie je na zemi a nespravil Double jump                                                    //double jump
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);      //hrač opäť vyskoči
                jumpTimeCounter = jumpTime;                     //počitanie vyskoku = času vyskoku
                noJumping = false;
                doubleJump = false;
                jumpSound.Play();

            }

        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.F) || Input.GetMouseButton(0)) && !noJumping)  //ovladanie space, klavesa F 
        {                                                                               //ak je zatlačene tlačidlo 
            if (jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);      //hrač vyskoči vyšie
                jumpTimeCounter -= Time.deltaTime;
               // jumpSound.Play();
            }

        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.F) || Input.GetMouseButtonUp(0) )     //ovladanie space, klavesa F  
        {                                                                      //ak nie je zaltačene tlačidlo

            jumpTimeCounter = 0;                
            noJumping = true;

        }

        if (grounded)       //ak je naš hrač na zemi
        {

            jumpTimeCounter = jumpTime; //moze opäť skakať
            doubleJump = true;      //može vykonať double jump

        }

        myAnimator.SetBool("Grounded", grounded); //hodi animaciu na zemi
    }
    

public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")              //game over hraca
        {

            theGameManager.RestartGame();                   //restartovanie hry
            moveSpeed = moveSpeedStore;                         //pamatanie rychlosti
            speedMilestoneCount = speedMilestoneCountStore;         //pamatanie 1hodnoty zrychlovania
            speedIncreaseMilestone = speedIncreaseMilestoneStore;//pamatanie dalsiej hodnoty zrychlovania
            DeathSound.Play();      // zvukovy efekt smrti      
            //stopPlay.Stop();

        }
    }


    public void PauseRestart()              //pre pause menu
    {
        moveSpeed = moveSpeedStore;                         //pamatanie rychlosti
        speedMilestoneCount = speedMilestoneCountStore;         //pamatanie 1hodnoty zrychlovania
        speedIncreaseMilestone = speedIncreaseMilestoneStore;//pamatanie dalsiej hodnoty zrychlovania
    }

}
