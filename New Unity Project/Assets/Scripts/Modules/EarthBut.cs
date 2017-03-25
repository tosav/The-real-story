using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EarthBut : MonoBehaviour {
    public GameObject Earth;
    private bool k=false;//true - возрастание; false - убывание
    private float i = 1;
    private double z = 0;
    private int time=10;
    public Transform enemy;
    private float gravitationalForce = 7;
    private Vector3 directionOfBirdFromPlanet;
    /*void Start()
    {
        directionOfBirdFromPlanet = Vector3.up;
    }
    void FixedUpdate()
    {
        directionOfBirdFromPlanet = (transform.position - enemy.position).normalized;
        enemy.GetComponent<Rigidbody2D>().AddForce(directionOfBirdFromPlanet * gravitationalForce);
    }*/
    void FixedUpdate()
    {
        if (GameManager.instance.GameStarted)
        {
            switch (GameManager.instance.GameLevel)
            {
                case 1:
                    if (k)
                    {
                        i++;
                        if (i > 500)
                            k = !k;
                    }
                    else
                    {
                        i--;
                        if (i < -500)
                            k = !k;
                    }
                    Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime / time * i);
                    break;
                case 2:
                    time = 5;
                    if (k)
                    {
                        i = i * 1.1f;
                        if (i > 500)
                            k = !k;
                    }
                    else
                    {
                        i = i / 1.001f;
                        if (i < 1)
                            k = !k;
                    }
                    Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime / time * i);
                    break;
                case 3:
                    time = 12;
                    if (k)
                    {
                        i += 0.01f;
                        if (i > 3600)
                            k = !k;
                    }
                    else
                    {
                        i -= 0.01f;
                        if (i < -3600)
                            k = !k;
                    }
                    Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime * 200 * Convert.ToSingle(Math.Sin(Convert.ToDouble(i))));
                    break;
                default:
                    Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime / time * 5);
                    break;
            }
        }
    }
    
}
