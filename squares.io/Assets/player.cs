using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class player : MonoBehaviour {

    public float speed = 10f;
    PlayerController controller;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 moveVelocity = moveInput.normalized * speed * Time.deltaTime;
        controller.Move(moveVelocity);
    }
}
