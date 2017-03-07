using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectory : MonoBehaviour
{
    public Transform planet;
    private float forceAmountForRotation = 5;
    private Vector3 directionOfPlanetFromBird;
 /*   private bool allowForce;
    public float delayTimer = 2f;
    float timer;*/

    void Start()
    {
        directionOfPlanetFromBird = Vector3.zero;
      //  timer = delayTimer;
    }
    void Update()
    {/*
        allowForce = false;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            allowForce = true;
            timer = delayTimer;
        }*/
        directionOfPlanetFromBird = transform.position - planet.position;
        transform.right = Vector3.Cross(directionOfPlanetFromBird, Vector3.forward);
    }
    void FixedUpdate()
    {
     /*   if (allowForce)
            GetComponent<Rigidbody2D>().AddForce(transform.right * forceAmountForRotation);*/
    }
}
