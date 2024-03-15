using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float force = 30f;
    /*public float speed = 20f;*/
    private float horizontalInput;
    private float verticalInput;
    private float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {

        // 차량에 힘을 가해 초기속도를 만들기.
        rb = GetComponent<Rigidbody>();
        Debug.Log("Adding force");
        //rb.AddForce(transform.forward * force, ForceMode.VelocityChange);
        rb.AddForce(transform.forward * force);
        /*transform.Translate(Vector3.forward * speed * Time.deltaTime);*/


    }

    // Update is called once per frame
    void Update()
    {
        // 회전 속도계수
        turnSpeed = 10;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        /*transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);*/

        // 좌우 입력에 따라 차량 회전
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
        // 앞뒤 입력에 따라 차량 전후진
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput);
    }
}
