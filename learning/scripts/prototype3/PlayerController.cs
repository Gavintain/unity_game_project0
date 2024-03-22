using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isOnGround = true;
    public bool gameover = false;
    private Rigidbody playerRb;
    private float jumpForce = 500;
    public float gravity_modifier = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravity_modifier;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space))&&(isOnGround)){
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Obstacle")){
            gameover = true;
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
        else{
            isOnGround = true;
        }

    }

}
