using System;
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
    public GameObject back;
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
        back = GameObject.FindGameObjectWithTag("Back");
    }
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Planet"))
            GetComponent<Rigidbody2D>().AddForce((GameObject.FindGameObjectWithTag("Planet").transform.position - transform.position).normalized * gravity);
    }
    private void fixi(Collision2D collision)
    {
        fix = gameObject.AddComponent<FixedJoint2D>();
        fix.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        fix.autoConfigureConnectedAnchor = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (repeat.GetComponent<ScrollMenu>().speedY != 10)
        {
            if (collision.gameObject.CompareTag("Planet")) {
                fixi(collision);
				if (c)
					c.State();
            }
            else if(collision.gameObject.CompareTag("Coin"))
            {
                Destroy(collision.gameObject);
                PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
            } 
            else if (collision.gameObject.CompareTag("Building"))
            {
                Firebase.Analytics.Parameter[] LevelPassParameters = {
            new Firebase.Analytics.Parameter(
            Firebase.Analytics.FirebaseAnalytics.ParameterLevel, PlayerPrefs.GetInt("level")),
            new Firebase.Analytics.Parameter("dateOver", DateTime.Now.ToString()),
            new Firebase.Analytics.Parameter("NumAttempt", PlayerPrefs.GetInt("attempt"))
            };
                Firebase.Analytics.FirebaseAnalytics
                  .LogEvent("LevelOver", LevelPassParameters);
                PlayerPrefs.SetInt("attempt", PlayerPrefs.GetInt("attempt") + 1);
                repeat.GetComponent<ScrollMenu>().speedY = 10;
                bom = Instantiate(boom);
				bom.GetComponent<Transform>().position = transform.position;
                Destroy(gameObject);
                Destroy(collision.gameObject);
                Destroy(bom, bom.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);
                GameManager.instance.PlayerCollided();
                MobileAdsScript scr = back.GetComponent<MobileAdsScript>();
                scr.RequestInterstitial();
                scr.ShowInterstitial();
            }
        }

    }
}
