using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform planet;
    private FixedJoint2D fix;
    public Sprite[] buildings;
    public GameObject repeat;
    public GameObject next;
    public GameObject boom;
    public int i = 0;
	public Controller c;
	private GameObject bom;
    public float gravity=0;
    void Start()
    {
        repeat = GameObject.FindGameObjectWithTag("Repeat");
        next = GameObject.FindGameObjectWithTag("Next");
        gameObject.GetComponent<SpriteRenderer>().sprite = buildings[i];
        if (gameObject.GetComponent<PolygonCollider2D>())
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
        c = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
    }
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Planet"))
            GetComponent<Rigidbody2D>().AddForce((GameObject.FindGameObjectWithTag("Planet").transform.position - transform.position).normalized * gravity);
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
            else if (collision.gameObject.CompareTag("Building"))
            {
                repeat.GetComponent<ScrollMenu>().speedY = 10;
                MobileAdsScript scr= c.GetComponent<MobileAdsScript>();
                scr.RequestInterstitial();
                scr.ShowInterstitial();
                bom = Instantiate(boom);
				bom.GetComponent<Transform>().position = transform.position;
                Destroy(gameObject);
                Destroy(collision.gameObject);
                Destroy(bom, bom.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);
                GameManager.instance.PlayerCollided();

            }
        }

    }
}
