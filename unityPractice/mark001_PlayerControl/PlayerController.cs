using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // logical funciontioning variables
    private float horizontalInput;
    public float wheelTorque;
    public float brakeFactor;
    public float steeringWhl;
    private Vector3 wheelGlobalAngVelocity;
    private Vector3 wheelLocalAngVelocity;

    // data access variables
    private GameObject FPCamera;
    public GameObject frontLeftWheel;
    public GameObject frontRightWheel;
    
    //debug variables

    private void Start()
    {
        // disables FP camera on scene start
        FPCamera = GameObject.Find("FPcamera");
        FPCamera.SetActive(false);
    }

    void FixedUpdate()
    {
        // controls the first person camera
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FPCamera.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            FPCamera.SetActive(false);
        }

        //make the wheels spin to move the vehicle forward
        if (Input.GetKey(KeyCode.K))
        {
            frontLeftWheel.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right * wheelTorque);
            frontRightWheel.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right * wheelTorque);
        }

        // make the wheels brake or use reverse gear
        if (Input.GetKey(KeyCode.L))
        {
            // gets the angular velocity to decides what to do
            wheelGlobalAngVelocity = frontLeftWheel.GetComponent<Rigidbody>().angularVelocity;
            wheelLocalAngVelocity = frontLeftWheel.transform.InverseTransformVector(wheelGlobalAngVelocity);
            
            // use brakes if the ang speed on local x-axis > 0
            if (wheelLocalAngVelocity.x > 0)
            {
                frontLeftWheel.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.left * brakeFactor);
                frontRightWheel.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.left * brakeFactor);
            }
            // use reverse gear if the ang speed on local x-axis <= 0
            else
            {
                frontLeftWheel.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.left * wheelTorque);
                frontRightWheel.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.left * wheelTorque);
            }
        }

        //turns the vehicle by rotating wheels around y-axis
        horizontalInput = Input.GetAxis("Horizontal");
        frontLeftWheel.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.up * steeringWhl * horizontalInput);
        frontRightWheel.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.up * steeringWhl * horizontalInput);
    }
}
