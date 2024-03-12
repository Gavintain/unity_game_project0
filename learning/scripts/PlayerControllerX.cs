using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float offset_ForwardSpeed;
    public float offset_UpSpeed;
    public float offset_RotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    public float elevateInput;
    public float rightAndleftTiltInput;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        elevateInput = Input.GetAxis("UpAndDown");
        rightAndleftTiltInput = Input.GetAxis("RightAndLeft");

        // move the plane forward of maxium offset_ForwardSpeed
        float speed = offset_ForwardSpeed * Time.deltaTime * verticalInput;
        transform.Translate(Vector3.forward * speed);

        // tilt the plane up/down based on up and down key 
        /*transform.Translate(Vector3.up * (offset_UpSpeed + speed) * Time.deltaTime * elevateInput);*/
        transform.Translate(Vector3.up * (offset_UpSpeed) * Time.deltaTime * elevateInput);

        // tilt the plane left/right based on left and right key 
        transform.Rotate(Vector3.forward * offset_RotationSpeed * Time.deltaTime * rightAndleftTiltInput);

        // roate the plane based on the left and right button
        transform.Rotate(Vector3.up * offset_RotationSpeed * Time.deltaTime * horizontalInput);
    }
}
