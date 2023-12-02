using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }
    void Update()
    {

        float sideForse = Input.GetAxis("Horizontal") * rotationSpeed ;

        if (sideForse != 0.0f)
        {
            rigidBody.angularVelocity = new Vector3(0.0f, sideForse, 0.0f);
        }

        float forwardForce = Input.GetAxis("Vertical") * moveSpeed ;

        if (forwardForce != 0.0f)
        {
            rigidBody.velocity = rigidBody.transform.forward * forwardForce;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Slow")
        {
            Debug.Log("+");
            moveSpeed = 3f;
        }
       
        if(other.gameObject.tag == "Fast")
        {
            Debug.Log("-");
            moveSpeed = 10f;
        }
    }
      
}