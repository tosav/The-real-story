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
    public GameObject Boom;
    public int i = 0;
    public Controller c;
    void Start()
    {
        building.GetComponent<Rigidbody2D>().gravityScale = 0f;
        building.GetComponent<SpriteRenderer>().sprite = buildings[i];
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (repeat.GetComponent<ScrollMenu>().speed != 10)
        {
            if (collision.gameObject.CompareTag("Earth")) {
                fix= building.AddComponent<FixedJoint2D>();
                fix.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
                fix.autoConfigureConnectedAnchor = false;
                c.State();
            }
            if (collision.gameObject.CompareTag("Building"))
            {
                repeat.GetComponent<ScrollMenu>().speed = 10;
                fix = building.AddComponent<FixedJoint2D>();
                fix.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
                fix.autoConfigureConnectedAnchor = false;
            }
           /* if (collision.gameObject.CompareTag("Enemy"))
            {
                GameObject bo =Instantiate(Boom);
                print(collision.transform.position);
                bo.transform.position = collision.transform.position;
                bo.transform.localScale = new Vector3(10f,10f);
                bo.GetComponent<SpriteRenderer>().enabled=true;
                repeat.GetComponent<ScrollMenu>().speed = 10;
            }*/

        }

    }
}
