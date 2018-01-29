using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    // We are making the variables for the character
    // Remember that Vector3 is a type which is the x, y, z which means that this could be with offsets.
    Vector3 velocity;
    // Rigidbody is part of the unity system and the rigidbody comes with physics.
    Rigidbody rb;

    // In the start method we are getting the rigidbody component
    // of this variable called "rb"
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // This method is where the velocity is supposted to be equal to this velocity.
    // The move will also be with the fixedUpdate.
    public void Move(Vector3 _velocity)
    {
        // velocity has to be = _velocity
        velocity = _velocity;
    }

    // LookAt is where our player is going to look at our mouse pointer
    public void LookAt(Vector3 lookPoint)
    {
        // In the method we will be using a Vector3 variable which is private and call it heightCorrectedPoint;
        // and then this will be null so we will = that to a new Vector3 and in brackets we will be using lookPoint which will look at the x,
        // and lookpoint on the z. 
        // and transform.LookAt, we of course want to look at  our height corrected Point;
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    // In the fixedUpdate, this is where all lines of code is going to move the player
    void FixedUpdate()
    {
        // So we use rb.MovePosition so it can move in a certain position.
        // We then inside brackets we will say that the rb or rigidbody. the position will be add on to the velocity of the player and multiply it by Time.fixedDeltaTime
        // This will make it move
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    // We finished the player movement stats and looking around and all of that now we need to move on to the gun
    // So lets go to the bullet class
}
