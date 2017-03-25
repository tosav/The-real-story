﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_event : MonoBehaviour {

    public GameObject repeat;
    public GameObject boom;
    private GameObject bom;

    void OnCollisionEnter2D(Collision2D collision)
    {
		if (repeat.GetComponent<ScrollMenu> ().speedY != 10)
        {
            Destroy(gameObject);
            bom = Instantiate (boom);
			bom.GetComponent<Transform> ().position = transform.position;
			bom.GetComponent<Animator> ().Play (boom.GetComponent<Animator> ().GetHashCode ());
            
            if (!collision.gameObject.CompareTag("Planet"))
                Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(bom, bom.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);
        } else 
		{
			Destroy (this);
		}

    }
}
