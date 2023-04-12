using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicleController : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        //moves the enemy car forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
