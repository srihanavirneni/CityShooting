using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float LookSense = 3f;

    [SerializeField]
    private float thrusterForce = 1000f;

    [Header("Spring Settings:")]
    [SerializeField]
    private JointDriveMode jointMode;
    [SerializeField]
    private float jointSpring = 20f;
    [SerializeField]
    private float jointMaxForce = 40f;

    private PlayerMotor motor;
    private ConfigurableJoint joint;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        joint = GetComponent<ConfigurableJoint>();

        SetJointSettings(jointSpring);
    }

    private void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * LookSense;

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        float camerarotation = xRot * LookSense;

        motor.RotateCamera(camerarotation);

        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            _thrusterForce = Vector3.up * thrusterForce;
            SetJointSettings(0f);
        }else
        {
            SetJointSettings(jointSpring);
        }

        motor.ApplyThruster(_thrusterForce);
    }

    private void SetJointSettings(float _jointSpring)
    {
        joint.yDrive = new JointDrive{mode = jointMode, positionSpring = jointSpring, maximumForce = jointMaxForce};
    }

}
