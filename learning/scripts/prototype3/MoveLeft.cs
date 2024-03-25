using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5.0f;
    public PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameover){
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.y < -5){
                Destroy(gameObject);
            }
        }
        else{
            // Destroy(gameObject);
        }
 
    }
}
