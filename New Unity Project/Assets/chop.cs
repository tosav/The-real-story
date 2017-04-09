using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chop : MonoBehaviour {
    
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce((GameObject.FindGameObjectWithTag("Planet").transform.position - transform.position).normalized* 9.8f);
    }
}
