using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPlayerController : MonoBehaviour
{
    public float speed =50.0f;
    private Rigidbody playerRb;
    private float zBound =6;
    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();   
       ConstraintPlayerPosition();

    }

     
    
    void MovePlayer()
    {
        
        float verticalInput=Input.GetAxis("Vertical");
        float horizontalInput=Input.GetAxis("Horizontal");

        playerRb.AddForce(Vector3.forward*speed*verticalInput);
        playerRb.AddForce(Vector3.right*speed*horizontalInput);
    } 

    void ConstraintPlayerPosition()
    {
 if(transform.position.z < -zBound)
        {
        transform.position=new Vector3(transform.position.x,transform.position.y,-zBound);
           
        }
             if(transform.position.z > zBound)
            {
        transform.position=new Vector3(transform.position.x,transform.position.y,zBound);
           
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with enemy");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup1"))
        {  
            Destroy(other.gameObject);    
        }
    }
}
