using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform planet;
    private FixedJoint2D fix;
    public Sprite[] buildings;
    public GameObject repeat;
    public GameObject nextlevel;
    public GameObject boom;
    public int i = 0;
	public Controller c;
	private GameObject bom;

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
        gameObject.GetComponent<SpriteRenderer>().sprite = buildings[i];
        if (gameObject.GetComponent<PolygonCollider2D>())
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (repeat.GetComponent<ScrollMenu>().speedY != 10)
        {
            fix = gameObject.AddComponent<FixedJoint2D>();
            fix.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            fix.autoConfigureConnectedAnchor = false;

            if (collision.gameObject.CompareTag("Planet")) {
				if (c)
					c.State();
            }
            if (collision.gameObject.CompareTag("Building"))
            {
                repeat.GetComponent<ScrollMenu>().speedY = 10;
				bom = Instantiate(boom);
				bom.GetComponent<Transform>().position = transform.position;
				bom.GetComponent<Animator>().Play(boom.GetComponent<Animator>().GetHashCode());

            }
        }

    }
}
