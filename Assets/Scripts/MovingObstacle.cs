using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed;
    bool movingLeft;

    public Rigidbody rb;
    public float pushForce;

    bool pushing;

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.collider.tag == "Player")
       {
            pushing = true;
       }
    }


    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > 10)
        {
            movingLeft = true;
        } 
        if (transform.position.x < -10)
        {
            movingLeft = false;
        }

        if (movingLeft)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        } 
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        
        if (pushing)
        {
            if (movingLeft)
            {
                rb.AddForce(-pushForce, 0, 0, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(pushForce, 0, 0, ForceMode.Impulse);
            }
         
        }
        
    }

}
