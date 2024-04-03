using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody enemyRb;
    public GameObject player;
    private float speed = 70f;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {   
        if(transform.position.y < -5){
            Destroy(gameObject);
        }
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce( moveDirection * speed * Time.deltaTime);
    }
}
