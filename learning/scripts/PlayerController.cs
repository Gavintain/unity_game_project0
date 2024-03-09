using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float force = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Adding force");
        //rb.AddForce(transform.forward * force, ForceMode.VelocityChange);
        rb.AddForce(transform.forward * force);


    }

    // Update is called once per frame
    void Update()
    {
    }
}
