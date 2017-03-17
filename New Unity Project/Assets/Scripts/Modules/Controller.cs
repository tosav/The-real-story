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
	public float delayTimer= 2f;
	float timer;

    private void Start()
    {
        Build = new GameObject[Building.GetComponent<Building>().buildings.Length];//количество игровых обьектов на поле
        Build[0] = Building;
        Build[0].GetComponent<Building>().c=this;
        Build[0].GetComponent<Building>().i = 0;
        Bul.GetComponent<Building>().buildings = Building.GetComponent<Building>().buildings;
		timer = delayTimer;
		enemy.GetComponent<Enemy_event>().repeat= Build[0].GetComponent<Building>().repeat;
    }

    public void State()
    {
        if (i < Building.GetComponent<Building>().buildings.Length)
        {
            Build[i + 1] = Instantiate(Bul);
            Build[i + 1].GetComponent<Building>().i = i + 1;
            Build[i + 1].GetComponent<Building>().c = this;
            Build[i + 1].GetComponent<Building>().nextlevel = Build[0].GetComponent<Building>().nextlevel;
            Build[i + 1].GetComponent<Building>().repeat = Build[0].GetComponent<Building>().repeat;
            Build[i + 1].GetComponent<Building>().boom = Build[0].GetComponent<Building>().boom;
            i ++;
        }
        else if (i == Building.GetComponent<Building>().buildings.Length)
        {
            Building.GetComponent<Building>().repeat.GetComponent<ScrollMenu>().speed = 10f;
            Building.GetComponent<Building>().nextlevel.GetComponent<ScrollMenu>().speed = 10f;
        }
    }
    private void OnMouseDown()
    {
        Build[i].GetComponent<Rigidbody2D>().gravityScale = 9.8f;
    }
	private void Update()//тут будут рождаться враги
	{
		timer -= Time.deltaTime;
		if (timer <= 0 & Building.GetComponent<Building>().repeat.GetComponent<ScrollMenu>().speed != 10f) {
			timer= delayTimer;
			GameObject en = Instantiate (enemy);
		}
	}
}
