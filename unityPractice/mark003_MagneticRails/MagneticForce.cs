using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticForce : MonoBehaviour
{
    public Rigidbody rigidBd;
    public float reverseAccel;
    // Start is called before the first frame update
    void Start()
    {
        rigidBd = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBd.AddRelativeForce(Vector3.down * reverseAccel, ForceMode.Acceleration);
    }
}
