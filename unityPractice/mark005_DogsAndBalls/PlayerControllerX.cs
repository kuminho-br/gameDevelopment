using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float dogCooldown;
    private float lastDogRunTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && ((Time.time-lastDogRunTime) > dogCooldown))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastDogRunTime = Time.time;
        }
    }
}
