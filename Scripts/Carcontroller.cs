/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontroller : MonoBehaviour*/
//{
    // Start is called before the first frame update
    /*   public float speed = 10f;  // Speed of the car
       public float rotationSpeed = 100f;  // Rotation speed of the car

       private CharacterController controller;

       void Start()
       {
           controller = GetComponent<CharacterController>();
       }

       void Update()
       {
           float moveHorizontal = Input.GetAxis("Horizontal");
           float moveVertical = Input.GetAxis("Vertical");

           Vector3 moveDirection = transform.forward * moveVertical * speed * Time.deltaTime;

           controller.Move(moveDirection);

           transform.Rotate(Vector3.up, moveHorizontal * rotationSpeed * Time.deltaTime);
       }*/


//}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Carcontroller : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;
    AudioSource audio;
    public AudioSource audioBreak;
  
   

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private void Start()
    {
        audio=GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        GetInput();   
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        Soundplay();



    }

    private void GetInput()
    {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);

       
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    private void Soundplay()
    {
       if(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
        {
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
       if(Input.GetKey(KeyCode.Space))
        {
            audioBreak.Play();
        }
        else
        {
            audioBreak.Stop();
        }
       
    }
}

