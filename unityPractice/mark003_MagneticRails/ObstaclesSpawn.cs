using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    public GameObject[] obstacles;
    public float offsetFromPlayer;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        this.transform.position = new Vector3 (playerTransform.position.x + offsetFromPlayer, transform.position.y, transform.position.z);

        InvokeRepeating("SpawnObstacle", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerTransform.position.x + offsetFromPlayer, transform.position.y, transform.position.z);
    }
    void SpawnObstacle()
    {
        transform.Rotate(Vector3.right, Random.Range(0, 360));
        Instantiate(obstacles[0], transform.position, transform.rotation);
    }
}
