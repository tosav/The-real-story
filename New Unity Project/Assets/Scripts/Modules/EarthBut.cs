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
    void Start()
    {
    }
    void Update()
    {
        switch (System.Int32.Parse(SceneManager.GetActiveScene().name.Replace("Level", "") )) {
            case 1:
                if (k) {
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
                    i=i*1.1f;
                    if (i > 500)
                        k = !k;
                }
                else
                {
                    i=i/1.001f;
                    if (i < 1)
                        k = !k;
                }
                Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime / time * i);
                break;
            case 3:
                time = 12;
                if (k)
                {
                    i+=0.01f;
                    if (i > 3600)
                        k = !k;
                }
                else
                {
                    i -= 0.01f;
                    if (i < -3600)
                        k = !k;
                }
                Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime *200*Convert.ToSingle(Math.Sin(Convert.ToDouble(i))));
                break;

        }
    }
    
}
