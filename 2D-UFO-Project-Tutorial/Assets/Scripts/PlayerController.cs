﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // FIRST THINGS FIRST
    public Text countText; // Must be named equally to the property in the editor in order to be matched with it, I guess
    public Text timeText;
    public Text winText;
    public float forceMagnitude; // More precise name...
    
    private int pickUpsCount;
    private Rigidbody2D rb2dReference; // A reference to a component in the same game object.

    //private float startTime;

    void Start ()
    {
        rb2dReference = GetComponent<Rigidbody2D>();
        //ForceVectorMagnitude = 25; Unity editor actually adds a field automatically for this

        pickUpsCount = 0;

        UpdateUICount();
        UpdateUITime();
        winText.text = "";


        //startTime = Time.time; //This actually gives the total time since the start of the game.
    }



    // We wanna check every frame for user input.
    // And then apply that input to move our game object (the player).
    // FOR CHECKING AND APPLY THIS INPUT - THERE ARE TWO CHOICES.
    // Update() - Called before rendering a frame. (Most code go here cause most things happen here)
    // FixedUpdate() - Called just before performing any physics calculations. (Physics code goes here)

    private void Update()
    {
        //UpdateUITime();
    }

    // CODE FOR PHYSICS
    void FixedUpdate()
	{
        // Unity documentations seems to be pretty good...
        // This input will be used for applying forces to the rigid body
        //float moveHorizontal = Input.GetAxis("Horizontal"); // InputManager does a great job recording automatically from the keys at the keybord. 
		//float moveVertical = Input.GetAxis("Vertical");
        //Input.acceleration;
        //Input.deviceOrientation;
        //Input.accelerationEvents;

        // FOR MOBILE

        // TOUCHSCREEN INPUT
        //Touch[] myTouches = Input.touches;
        //float horizontalVector = 0;
        //float verticalVector = 0;

        //for (int i = 0; i < Input.touchCount; i++)
        //{
        //    Touch myTouch = Input.GetTouch(i);
        //    Vector2 touchPosition = myTouch.position;

        //    Vector2 origin = new Vector2(Screen.width / 2, Screen.height / 2);

        //    horizontalVector = touchPosition.x - origin.x;
        //    verticalVector = touchPosition.y - origin.y;

        //}



        //// Actual interaction with the physics engine.
        //if (horizontalVector != 0 || verticalVector !=0)
        //{
        //    // Force them to have a magnitude of one by dividing them by themselves.
        //    horizontalVector = horizontalVector / Mathf.Abs(horizontalVector);
        //    verticalVector = verticalVector / Mathf.Abs(verticalVector);

        //    Vector2 forceVector = new Vector2(horizontalVector, verticalVector) * forceMagnitude;
        //    rb2dReference.AddForce(forceVector);
        //}
        //else
        //{
        //    Vector2 forceVector = new Vector2(moveHorizontal, moveVertical) * forceMagnitude;
        //    rb2dReference.AddForce(forceVector);
        //}


        // ACCELEROEMTER INPUT

        float horizontalVector = Input.acceleration.x;
        float verticalVector = Input.acceleration.y;

        Vector2 forceVector = new Vector2(horizontalVector, verticalVector) * (forceMagnitude * 3);
        rb2dReference.AddForce(forceVector);
        

        UpdateUITime();
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            
            AddUpCount();
        }

        // It's better to make the comparison only when adding up the count, so this code should be on that function.
        //if (pickUpsCount == 12)
        //{
        //    //float totalTime = Time.time - startTime;
        //    float totalTime = Time.time; // TIME IN SECONDS SINCE THE START OF THE GAME. Just for the sake of clarity. or "Beggining of this frame"
        //    winText.text = "CONGRATULATIONS, YOU WON THE GAME!!! \nIN JUST " 
        //        + totalTime.ToString()
        //        + " SECONDS";
        //}
        
    }

    private void AddUpCount()
    {
        pickUpsCount++;
        UpdateUICount();
    }

    private void UpdateUICount()
    {
        countText.text = "Count: " + pickUpsCount.ToString();

        if (pickUpsCount >= 12)
        {
            //float totalTime = Time.time - startTime;
            float totalTime = Time.time; // TIME IN SECONDS SINCE THE START OF THE GAME. Just for the sake of clarity. or "Beggining of this frame"
            winText.text = "CONGRATULATIONS, YOU WON THE GAME!!! \nIN JUST "
                + totalTime.ToString()
                + " SECONDS";
        }
    }

    private void UpdateUITime()
    {
        int seconds = (int) Time.time;
        timeText.text = "Time: " + seconds.ToString() + " Seconds";


        
    }
}

