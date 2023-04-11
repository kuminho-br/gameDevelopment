using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float trainAccel; // forward acceleration of the train
    public float brakeAccel; // acceleration that the brakes applies on the train
    private Rigidbody rigidBd; // used to store the rigidbody component of the actual GameObject
    private Rigidbody rigidBdFather; // stores the father's rigdbody
    public float torqueAccel; // angular acceleration, unit: rad/s²
    public Vector3 torqueVector; // vector used to apply the torque to rotate around the rail
    public float lateralInput; // input used to rotate the train moves around the rail

    void Start()
    {
        rigidBd = this.GetComponent<Rigidbody>(); // gets the rigibody component of the atual GameObject
        rigidBdFather = this.GetComponentInParent<Rigidbody>(); // gets rigidbody from the father
    }

    void FixedUpdate()
    {
        // translation movement
        if (Input.GetKey(KeyCode.K)) // input for the forward acceleration
        {
            // forward movement
            rigidBd.AddRelativeForce(Vector3.right * trainAccel * Time.deltaTime, ForceMode.Impulse);
        }
        else if (Input.GetKey(KeyCode.L)) // inputs for the brakes and reverse gear
        {
            // brakes
            rigidBd.AddRelativeForce(Vector3.left * brakeAccel * Time.deltaTime, ForceMode.Impulse);
        }

        // rotation movement
        lateralInput = Input.GetAxis("Horizontal");
        rigidBdFather.AddRelativeTorque(torqueVector * torqueAccel * lateralInput * Time.deltaTime, ForceMode.Acceleration);

    }
}
