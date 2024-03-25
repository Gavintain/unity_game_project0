using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isOnGround = true;
    public bool gameover = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem groundParticle;
    public AudioClip[] jumpSound;
    public AudioClip[] crashSound;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudioSource;
    private float jumpForce = 500;
    public float gravity_modifier = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravity_modifier;
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space))&&(isOnGround)&&(!gameover)){
            groundParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerAudioSource.PlayOneShot(jumpSound[Random.Range(0,3)],0.5f);
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Obstacle")){
            explosionParticle.Play();
            groundParticle.Stop();
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",Random.Range(1,3));
            playerAudioSource.PlayOneShot(crashSound[Random.Range(0,3)],0.5f);
            gameover = true;
            Debug.Log("Game Over!");
            // Destroy(gameObject);
        }
        else{
            if(groundParticle.isStopped){
                groundParticle.Play();
            }
            isOnGround = true;
        }

    }

    

}
