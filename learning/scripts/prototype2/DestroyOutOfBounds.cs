using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 29f;
    public float bottomBound = -5f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < bottomBound){
            Destroy(gameObject);
            Debug.Log(transform.position.z);
            // Destroy(player);
        }
    }
}
