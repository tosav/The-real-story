using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_event : MonoBehaviour {

    public GameObject repeat;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (repeat.GetComponent<ScrollMenu>().speed != 10)
        {
            if (collision.gameObject.CompareTag("Planet"))
            {
                print("earth");
            }
            if (collision.gameObject.CompareTag("Building"))
            {
                print("Building");
            }
            if (collision.gameObject.CompareTag("Enemy"))
            {
                print("Enemy");
            }
        }
    }
}
