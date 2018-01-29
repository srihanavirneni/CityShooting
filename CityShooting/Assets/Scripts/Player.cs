using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : Entitly {

    // We need some variables so this one will be a float and that is going to be = to 5
    public float moveSpeed = 5;

    // We need to use the Camera variable so this could actually look at the mouse pointer.
    Camera viewCamera;
    // We also need a player controller reference
    PlayerController controller;
    // and also a gun controller variable which handles all of the weapon input.
    GunController gun;

    // we want a protected override void Start so it will be called with the interface it has. Which is in the IDamageable script;
    protected override void Start () {
        // protected override needs a base and then the method
        base.Start();

        // we want to get the component of the controller which is the player controller
        controller = GetComponent<PlayerController>();
        // same thing with the gun
        gun = GetComponent<GunController>();
        // But the camera is equal to camera.main which will be the original camera and the main camera has a tag called main camera;
        viewCamera = Camera.main;
	}

	void Update () {
        // We are moving the player with the input it has
        // Vector3 moveInput will be equal to a new Vector3 and then we want to get the input of the axes; we will leave the y zero so it doesn't get these weird controls
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        // Also we need vector3 of move Velocity and will be equaled to moveInput that Vecotr3 private variable we just saw and normalize it.
        // normalize means that we will get a direction and we will multiply with the moveSpeed variable so we will have speed
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        // In the player controller it has a variable called move and so we say controller.Move and we want to move with how much velocity it has which will the speed and the normalizing so we pass in move Velocity;
        controller.Move(moveVelocity);

        // The player should look at our mouse with the input it has
        // So we are going to be using this test so this should work, this is called a ray, a ray is a line we can use for like a stealth game of lasers so that will be implemented with that with Debug.DrawLine;
        // In the test the ray has to be inside the camera and it should make a red line or whatever color and it will point it to the mouse position so it will need a ray to display if this is working;

        // So let's start
        // We need a private variable called ray and right now it is null so we need to equal that to viewCamera variable and unity has a wonderful method called screen point to ray and then it will point to what?
        // it will point to mouse position so we pass in input.mousePostition
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        // Now we need a Plane to make the ray stop when he hits the ground but still moves to the mouse position;

        // So private variable which is groundPlane and equal that to a new Plane and inside brackets, we want Vector3.up, and a vector3. zero. 
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        // Now we need a float and call it ray distance, and leave it null, you will see why this code is still working
        float rayDistance;

		// In the if statement we will say if groundPlane. this method called ray cast and inside brackets pass in the ray and then a comma(,) and after the comma, we will say out.
		// Before we continue, well what is out?
		// Out can be used to return the values in the same variable as a parameter of the method. When any changes are made to the parameter, it will be reflected in the variable.
        // Also the out key word causes arguments to be used by a reference. This is similar to the ref key word, except the ref requires that the variable be initialized before being. 
        // But what are refs?
        // Well this is not used in the code so i wont explain refs.

        // So now we know what an out word is. Now after the out we can pass in the ray distance. This will make it not null
		if (groundPlane.Raycast(ray, out rayDistance)) 
        {
            // Were going to make a variable called point which is private and it is a vector3;
            // this will be equal to this method called ray.GetPoint which will get the point of the ray distance so we pass in ray distance;
            Vector3 point = ray.GetPoint(rayDistance);
            // if you see a comment and it says in brackets a then that is a comment were not goint to read.
            //  (a)  Debug.DrawLine(ray.origin, point, Color.red);

            // In this line we are calling the lookat method in the player controller script. we also need to look at point which has a Vector3 point so we will say point;
            controller.LookAt(point);
        }

        // This is where we are going to click the button and the bullet or projectiles are going to shoot
        // So if input.GetMouseButton and in brackets 0 which means to left click.
        if (Input.GetMouseButton(0))
        {
            // then we will call the shoot method in the gun script which were going to see in a momment
            gun.Shoot();
        }

        // Lets move on to the player controller
	}
}
