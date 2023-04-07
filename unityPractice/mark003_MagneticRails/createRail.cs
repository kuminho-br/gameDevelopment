using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createRail : MonoBehaviour
{
    public GameObject train;
    public GameObject[] rails;

    // Start is called before the first frame update
    void Start()
    {

        TrainController trainControlScript = train.GetComponent<TrainController>();
        float creationSpeed = trainControlScript.speed;
        float spawnInterval = 50 / creationSpeed;
        InvokeRepeating("CreateRail", spawnInterval/100, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateRail()
    {
        Instantiate(rails[0], transform.position, rails[0].transform.rotation);
        transform.position += Vector3.forward * 50;
    }
}
