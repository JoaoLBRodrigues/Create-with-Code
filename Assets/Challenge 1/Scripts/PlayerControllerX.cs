using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 5.0f;
    public float rotationSpeed = 25.0f;
    public float verticalInput;
    private float horizontalInput;
    private float upDown = 25.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // transform.Translate(Vector3.up * rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
        // tilt the plane up/down based on up/down arrow keys
        transform.Translate(Vector3.up * upDown * verticalInput * Time.deltaTime /*Space.World*/);


    }
}
