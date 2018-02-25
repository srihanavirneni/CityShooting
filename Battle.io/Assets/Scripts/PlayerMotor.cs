using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float camerarotation = 0f;
    private float currentCameraRotationX = 0f;
    private Vector3 thrusterForce = Vector3.zero;

    [SerializeField]
    private float cameraRotationlimit = 85f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if (thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            currentCameraRotationX -= camerarotation;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationlimit, cameraRotationlimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }

    public void ApplyThruster(Vector3 _thrusterForce)
    {
        thrusterForce = _thrusterForce;
    }

    public void RotateCamera(float _cameraRotation)
    {
        camerarotation = _cameraRotation;
    }
}
