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
        Debug.Log("collision");
        if(collision.collider.tag == "Arrow"){
            Destroy(gameObject);
        }
    }

      void OnTriggerEnter2D(Collider2D collider){
          Debug.Log("trigger" + collider.tag);
        if(collider.tag == "Arrow"){
            Destroy(gameObject);
        }
    }
}       
