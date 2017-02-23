using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform planet;
    private FixedJoint2D fix;
    public GameObject building;
    public Sprite[] buildings;
    public GameObject repeat;
    public GameObject nextlevel;
    public int i = 0;
    public bool state;
    void Start()
    {
        building.GetComponent<Rigidbody2D>().gravityScale = 0f;
        building.GetComponent<SpriteRenderer>().sprite = buildings[i];
        state = false;
    }
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Earth")) {
            state = true;
            fix= building.AddComponent<FixedJoint2D>();
            fix.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            fix.autoConfigureConnectedAnchor = false;
        }
        if (collision.gameObject.CompareTag("Building"))
        {
            repeat.GetComponent<ScrollMenu>().speed = 10;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            repeat.GetComponent<ScrollMenu>().speed = 10;
        }

    }
}
