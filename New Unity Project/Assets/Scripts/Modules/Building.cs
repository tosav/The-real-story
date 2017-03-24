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
    public GameObject boom;
    public int i = 0;
	public Controller c;
	private GameObject bom;

    void Start()
    {
        building.GetComponent<Rigidbody2D>().gravityScale = 0f;
        building.GetComponent<SpriteRenderer>().sprite = buildings[i];
        building.AddComponent<PolygonCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
		if (repeat.GetComponent<ScrollMenu>().speedY != 10)
        {
            if (collision.gameObject.CompareTag("Planet")) {
                fix= building.AddComponent<FixedJoint2D>();
                fix.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
				fix.autoConfigureConnectedAnchor = false;
				if (c)
					c.State();
            }
            if (collision.gameObject.CompareTag("Building"))
            {
                repeat.GetComponent<ScrollMenu>().speedY = 10;
                fix = building.AddComponent<FixedJoint2D>();
                fix.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
				fix.autoConfigureConnectedAnchor = false;

				bom = Instantiate(boom);
				bom.GetComponent<Transform>().position = transform.position;
				bom.GetComponent<Animator>().Play(boom.GetComponent<Animator>().GetHashCode());

            }
        }

    }
}
