using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public float rotationSpeed = 80;
    void Start()
    {
        
    }

    void Update()
    {
        float horiaontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horiaontalInput * Time.deltaTime * rotationSpeed);
    }
}
