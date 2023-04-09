using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroys objects that move out of the player's field of view
        if (transform.position.z > 30 || transform.position.z < -15)
        {
            Destroy(gameObject);
        } 
    }
}
