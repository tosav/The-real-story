using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_trajectory : MonoBehaviour {
    
	void Start () {
        GetComponent<Rigidbody2D>().gravityScale = 9.8f;

    }

    void Update () {
		
	}
}
