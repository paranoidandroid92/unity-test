using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Arrow"){
            Destroy(gameObject);
        }
    }

      void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Arrow"){
            GameObject arrow = collider.gameObject;
            Rigidbody2D arrowBody = arrow.GetComponent<Rigidbody2D>();
            if(!arrowBody.isKinematic){ // Kinematic means hit wall already
                Destroy(gameObject);
            }
        }
    }
}       
