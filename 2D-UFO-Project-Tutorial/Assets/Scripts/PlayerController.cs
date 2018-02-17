using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // FIRST THINGS FIRST
    private Rigidbody2D Rb2dReference; // A reference to a component in the same game object.
    public float ForceMagnitude; // More precise name...

    void Start ()
    {
        Rb2dReference = GetComponent<Rigidbody2D>();
        //ForceVectorMagnitude = 25; Unity editor actually adds a field automatically for this
    }



	// We wanna check every frame for user input.
	// And then apply that input to move our game object (the player).
	// FOR CHECKING AND APPLY THIS INPUT - THERE ARE TWO CHOICES.
	// Update() - Called before rendering a frame. (Most code go here cause most things happen here)
	// FixedUpdate() - Called just before performing any physics calculations. (Physics code goes here)


	// CODE FOR PHYSICS
	void FixedUpdate()
	{
        // Unity documentations seems to be pretty good...
        // This input will be used for applying forces to the rigid body
        float MoveHorizontal = Input.GetAxis("Horizontal"); // InputManager does a great job recording automatically from the keys at the keybord. 
		float MoveVertical = Input.GetAxis("Vertical");

        // Actual interaction with the physics engine.
        Vector2 ForceVector = new Vector2(MoveHorizontal, MoveVertical) * ForceMagnitude;
        Rb2dReference.AddForce(ForceVector);


        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
        
    }


}

