using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyPlayerController : MonoBehaviour
{
    private Rigidbody playerRb;      
    private GameObject focalPoint;
    private float speed =3.0f;
    public bool hasPowerup;
    
    public GameObject powerupIndicater;
    // Start is called before the first frame update
    void Start()
    {
         playerRb=GetComponent<Rigidbody>();
         focalPoint=GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput=Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput *speed);
       powerupIndicater.transform.position=transform.position + new Vector3(0,-0.5f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("powerup"))
        {
            powerupIndicater.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(powerupCountdownRoutine());


        }
    }

    IEnumerator powerupCountdownRoutine()
    {
    yield return new WaitForSeconds(7);
    hasPowerup =false;
    powerupIndicater.gameObject.SetActive(false);

    }

    private void OnCollisonEnter(Collision collision)
    {
     
        if(collision.gameObject.CompareTag("enemy") && hasPowerup)
        {
            //Rigidbody enemyRigidbody= collision.gameObject.GetComponent<Rigidbody>();
            //Vector3 awayFromPlayer =(collision.gameObject.transform.position-transform.position);

            Debug.Log("Collid  with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
           //enemyRigidbody.AddForce(awayFromPlayer * + powerupStrengh,ForceMode.Impulse);
        }
    }
}
