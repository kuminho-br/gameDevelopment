using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput; //stores the side inputs of the user
    public float speed; //stores the move speed of the player
    public float xRange; //stores the distance the player can move along the x-axis
    private Vector3 initialPosition;//stores the player's position at the start of the game
    private Vector3 lastPosition;
    public GameObject projectilePrefab; //stores the projectile that will be thrown by the player


    // Start is called before the first frame update
    void Start()
    {
        //saves the initial position of the player
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //verify if the player is inside the boundary
        if (Math.Abs(transform.position.x) < (xRange - Math.Abs(initialPosition.x)))
        {
            //save the position of the player before let it move
            lastPosition = transform.position;

            //let the player moves
                //takes the input of the player
            horizontalInput = Input.GetAxis("Horizontal");
                //moves avatar according to the input and established speed
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
        else
        {
            //moves the avatar to the last valide position if it moves outside the boundary
            transform.position = lastPosition;
        }

        //captures a SpaceBar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //the player launchs a projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }        
    }
}
