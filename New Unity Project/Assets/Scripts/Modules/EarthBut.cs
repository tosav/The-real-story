using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EarthBut : MonoBehaviour {
    public GameObject Earth;
    private bool k=false;//true - возрастание; false - убывание
    private float i = 1;
    private int time=10; 
    void FixedUpdate()
    {//тут будут модели для траектории движения и вохможность их комбинировать  и задать через заданные значения
      
        switch (Convert.ToInt32(SceneManager.GetActiveScene().name.Substring(5)))//это временно
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
            case 4:
                time = 10;
                if (k)
                {
                    i = i * 1.2f;
                    if (i > 500)
                        k = !k;
                }
                else
                {
                    i = i / 1.005f;
                    if (i < 20)
                        k = !k;
                }
                Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime / time * i);
                break;
            case 5:
                time = 20;
                if (k)
                {
                    i += 0.01f;
                    if (i > 7230)
                        k = !k;
                }
                else
                {
                    i -= 0.01f;
                    if (i < -7230)
                        k = !k;
                }
                Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime * 200 * Convert.ToSingle(Math.Sin(Convert.ToDouble(i))));
                break;
            case 6:
                time = 10;
                if (k)
                {
                    i = i * 1.2f;
                    if (i > 500)
                        k = !k;
                }
                else
                {
                    i = i / 1.005f;
                    if (i < 20)
                        k = !k;
                }
                Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime / time * i);
                break;
            case 7:
                time = 30;
                if (k)
                {
                    i += 0.01f;
                    if (i > 7200)
                        k = !k;
                }
                else
                {
                    i -= 0.01f;
                    if (i < -7200)
                        k = !k;
                }
                Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime * 200 * Convert.ToSingle(Math.Sin(Convert.ToDouble(i))));
                break;
            case 8:
                time = 20;
                if (k)
                {
                    i += 0.01f;
                    if (i > 3630)
                        k = !k;
                }
                else
                {
                    i -= 0.01f;
                    if (i < -3630)
                        k = !k;
                }
                Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime * 300 * Convert.ToSingle(Math.Sin(Convert.ToDouble(i))));
                break;
            default:
                Earth.GetComponent<Transform>().Rotate(Vector3.forward * Time.deltaTime / time * 5);
                break;
        }
        
    }
    
}
