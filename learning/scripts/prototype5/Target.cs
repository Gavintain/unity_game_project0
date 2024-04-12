using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minForce = 4000f;
    private float maxForce = 6000f;
    private float randomTorque = 10f;
    private float backgroundBound = 4f;
    private int bottomBound = -15;
    public GameManager gameManager;
    public ParticleSystem particleSys;

    void Start()
    {
        // particleSys = GetComponentInChildren<ParticleSystem>(); 
        gameManager = FindObjectOfType<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position = RandomPosition();
    }

    float RandomForce(){
        return  Random.Range(minForce,maxForce) * Time.deltaTime ;
    }
    float RandomTorque(){
        return  Random.Range(-randomTorque,randomTorque);
    }
    Vector3 RandomPosition(){
        return new Vector3(Random.Range(-backgroundBound,backgroundBound),0,0);
    }
    void Update()
    {
        if(transform.position.y < bottomBound){
            Destroy(gameObject);
        }
        if (!gameManager.IsGameActive)
        {
            Destroy(gameObject);
        }
    }
    void OnMouseDown(){
        if(gameObject.CompareTag("bad"))
        {
            gameManager.UpdateScore(-1);

        }
        else{
            gameManager.UpdateScore(1);
        }
        Destroy(gameObject);
        Instantiate(particleSys,transform.position,transform.rotation);
        // float duration = particleSys.main.duration + particleSys.main.startLifetime.constantMax;
        // particleSys.Play();
        // Destroy(gameObject, duration);
    }
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("good"))
        {
            gameManager.GameOver();
        }

    }
}
