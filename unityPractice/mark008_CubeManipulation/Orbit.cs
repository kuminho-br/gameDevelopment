using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Orbit : MonoBehaviour
{
    float rotationSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            rotationSpeed += 0.25f;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            rotationSpeed -= 0.25f;
        }
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(Vector3.right * Input.GetAxis("Vertical") * Time.deltaTime * 100, Space.World);
        transform.Rotate(Vector3.forward * Input.GetAxis("Horizontal") * Time.deltaTime * 100, Space.World);
    }
}
