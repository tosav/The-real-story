using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {
    
    public float forceAmountForRotation =0.5f;
    public float forceforce = 0.999f;
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce((GameObject.FindGameObjectWithTag("Planet").transform.position - transform.position).normalized * 9.8f);
    }
    void FixedUpdate()
    {
        forceforce *= 0.9998f;
        forceAmountForRotation *= forceforce;
        GetComponent<Rigidbody2D>().AddForce(Vector3.Cross(transform.position - GameObject.FindGameObjectWithTag("Planet").transform.position, Vector3.forward) * forceAmountForRotation);
    }
}
