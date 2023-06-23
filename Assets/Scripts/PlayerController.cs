using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private variables

public ParticleSystem explosionParticle;
public ParticleSystem dirtParticle;
private AudioSource playerAudio;
   private Rigidbody playerRb;
   public float jumpForce=8;
   public float gravityModifier;
   public AudioClip jumpSound;
   public AudioClip crashSound;

   public bool isOnGround=true;
   public bool gameOver=false;
   private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
        playerAnim=GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        //dirtParticle.Stop();
        playerAudio=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            isOnGround=false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound,2.0f);
                   
        }
     
    } 
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
        isOnGround=true;
        dirtParticle.Play();

        }else if(collision.gameObject.CompareTag("Obstacle")){
            Debug.Log("Game Over");
            gameOver=true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound,2.0f);
            
        }
    }

   
}
