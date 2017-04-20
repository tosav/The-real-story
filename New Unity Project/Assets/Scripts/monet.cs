using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monet : MonoBehaviour {

    public float gravity = 0;
    private FixedJoint2D fix;
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Planet"))
            GetComponent<Rigidbody2D>().AddForce((GameObject.FindGameObjectWithTag("Planet").transform.position - transform.position).normalized * gravity);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        fix = gameObject.AddComponent<FixedJoint2D>();
        fix.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        fix.autoConfigureConnectedAnchor = false;
    }
}
