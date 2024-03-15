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

        // ������ ���� ���� �ʱ�ӵ��� �����.
        rb = GetComponent<Rigidbody>();
        Debug.Log("Adding force");
        //rb.AddForce(transform.forward * force, ForceMode.VelocityChange);
        rb.AddForce(transform.forward * force);
        /*transform.Translate(Vector3.forward * speed * Time.deltaTime);*/


    }

    // Update is called once per frame
    void Update()
    {
        // ȸ�� �ӵ����
        turnSpeed = 10;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        /*transform.Translate(Vector3.right * Time.deltaTime * horizontalInput);*/

        // �¿� �Է¿� ���� ���� ȸ��
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
        // �յ� �Է¿� ���� ���� ������
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput);
    }
}
