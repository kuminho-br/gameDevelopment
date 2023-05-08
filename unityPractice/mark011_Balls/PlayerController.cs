using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRgbd;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerUp = false;
    private float powerUpStrength = 15;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRgbd = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        
        playerRgbd.AddForce(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime);

        powerUpIndicator.transform.position = this.transform.position + new Vector3(0,-0.5f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    private IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRgbd = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = enemyRgbd.transform.position - this.transform.position;

            enemyRgbd.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collider with: " + collision.gameObject.name + " with Power Up set to " + hasPowerUp);
        }
    }
}
