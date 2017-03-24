using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_event : MonoBehaviour {

    public GameObject repeat;
    public GameObject boom;
    private GameObject bom;

    void OnCollisionEnter2D(Collision2D collision)
    {
		if (repeat.GetComponent<ScrollMenu> ().speedY != 10) {
			bom = Instantiate (boom);
			bom.GetComponent<Transform> ().position = transform.position;
			bom.GetComponent<Animator> ().Play (boom.GetComponent<Animator> ().GetHashCode ()); 
			if (collision.gameObject.CompareTag ("Planet")) {

				Destroy (boom);
				Destroy (gameObject);
			} else {
				Destroy (collision.gameObject);
				Destroy (boom);
				Destroy (gameObject);
			}
		} else 
		{
			Destroy (this);
		}
    }
}
