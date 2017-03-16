using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    public GameObject Building;
    public GameObject Bul;
    private GameObject[] Build;
    public GameObject enemy;
    private int i = 0;
    private void Start()
    {
        Build = new GameObject[Building.GetComponent<Building>().buildings.Length];//количество игровых обьектов на поле
        Build[0] = Building;
        Build[0].GetComponent<Building>().c=this;
        Build[0].GetComponent<Building>().i = 0;
        Bul.GetComponent<Building>().buildings = Building.GetComponent<Building>().buildings;
    }

    public void State()
    {
        if (i + 1 < Building.GetComponent<Building>().buildings.Length)
        {
            Build[i + 1] = Instantiate(Bul);
            Build[i + 1].GetComponent<Building>().i = i + 1;
            Build[i + 1].GetComponent<Building>().c = this;
            Build[i + 1].GetComponent<Building>().nextlevel = Build[0].GetComponent<Building>().nextlevel;
            Build[i + 1].GetComponent<Building>().repeat = Build[0].GetComponent<Building>().repeat;
            Build[i + 1].GetComponent<Building>().Boom = Build[0].GetComponent<Building>().Boom;
            i += 1;
        }
        else if (i + 1 == Building.GetComponent<Building>().buildings.Length)
        {
            Building.GetComponent<Building>().repeat.GetComponent<ScrollMenu>().speed = 10;
            Building.GetComponent<Building>().nextlevel.GetComponent<ScrollMenu>().speed = 10;
        }
    }
    private void OnMouseDown()
    {
        Build[i].GetComponent<Rigidbody2D>().gravityScale = 9.8f;
    }
    public void DestroyEnemy()
    {
        Destroy(enemy);
    }
}
