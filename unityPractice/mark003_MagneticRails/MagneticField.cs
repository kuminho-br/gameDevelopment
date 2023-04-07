using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MagneticField : MonoBehaviour
{
    public float forceFactor = 30f;
    List<Rigidbody> rgbdBalls = new List<Rigidbody>();
    Transform magnetPoint;
    

    private void Start()
    {
        magnetPoint = this.transform;
    }
    
    private void FixedUpdate()
    {
        
        foreach (Rigidbody rgbdBall in rgbdBalls)
        {
            rgbdBall.AddForce((magnetPoint.position.x - rgbdBall.position.x) * forceFactor * Time.deltaTime,
                                (magnetPoint.position.y - rgbdBall.position.y) * forceFactor * Time.deltaTime, 
                                0, ForceMode.Acceleration);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        rgbdBalls.Add(other.GetComponent<Rigidbody>());
    }
    private void OnTriggerExit(Collider other)
    {
        rgbdBalls.Remove(other.GetComponent<Rigidbody>());
    }

}
