using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Rigidbody2D body;
    public BoxCollider2D boxCollider;
    public Animator anim;
    public bool hit;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hit)
        {
            transform.right = new Vector3(body.velocity.x, body.velocity.y, 0).normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Ground")
        {
            hit = true;
            body.velocity = Vector3.zero;
            body.isKinematic = true;
            anim.SetTrigger("Wiggle");
        }
    }
}
