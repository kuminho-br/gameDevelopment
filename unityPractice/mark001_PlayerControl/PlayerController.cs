using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;

    // Update is called once per frame
    void Update()
    {
        //getting inputs from the player
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //moves the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //turns the vehicle
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);

        Transform fpCameraTransform = transform.Find("FPcamera");
        if (Input.GetKey(KeyCode.Space))
        {
            fpCameraTransform.gameObject.SetActive(true);
        }
        else
        {
            fpCameraTransform.gameObject.SetActive(false);
        }
    }
}