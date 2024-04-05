using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 500f;
    public int stimulationTimeSecond = 7;
    private Rigidbody playerRb;
    public GameObject focalPoint;
    public GameObject powerUpIndicator;
    public bool hasPowerUp = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        powerUpIndicator = transform.Find("PowerUpIndicator").gameObject;
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("PowerUp")){
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    IEnumerator PowerUpCountDownRoutine(){
        yield return new WaitForSeconds(stimulationTimeSecond);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision){
        GameObject otherObject = collision.gameObject;

        if (otherObject.CompareTag("Enemy")&& hasPowerUp){
            Vector3 forceDirection = (otherObject.transform.position - gameObject.transform.position).normalized;
            Rigidbody enemyRb = otherObject.GetComponent<Rigidbody>();
            float PowerStrength = 1500f;
            enemyRb.AddForce(forceDirection * PowerStrength * Time.deltaTime, ForceMode.Impulse);
            // Debug.Log("collide with " + otherObject.name + "with PowerUp" + hasPowerUp);
        }

    }
}
