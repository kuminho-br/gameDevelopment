using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    public float startDelay = 1.0f;
    private float spawnInterval = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CallMethods", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Generate random ball index
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // instantiate random ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }
    void CallMethods()
    {
        // generate random spawn interval
        spawnInterval = Random.Range(2.0f, 4.0f);
        Debug.Log(spawnInterval);
        Invoke("SpawnRandomBall",spawnInterval);
    }
}