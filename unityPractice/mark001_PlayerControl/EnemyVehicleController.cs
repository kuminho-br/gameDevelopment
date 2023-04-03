using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicleController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves the enemy car forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
