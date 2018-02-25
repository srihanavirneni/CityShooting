using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    Rigidbody2D rb;
    Vector2 velocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	public void Move(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
}
