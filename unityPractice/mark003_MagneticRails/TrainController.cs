using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float speed;
    public float trainAccel;
    private float lateralInput;
    private float forwardInput;
    public float turnSpeed;
    public Rigidbody rigidBd;

    void Start()
    {
        rigidBd = this.GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.K)) 
        {
            rigidBd.AddRelativeForce(Vector3.right * trainAccel, ForceMode.Acceleration);
        }
        else if(Input.GetKey(KeyCode.L))
        {
            rigidBd.AddRelativeForce(Vector3.left * trainAccel, ForceMode.Acceleration);
        }

        //lateralInput = Input.GetAxis("Horizontal");
        //rigidBd.AddRelativeForce(Vector3.back * turnSpeed * lateralInput, ForceMode.Acceleration);
        
    }

    // Update is called once per frame
    void Update()
    {
        lateralInput = Input.GetAxis("Horizontal");
        //forwardInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * lateralInput * turnSpeed);
    }
}
