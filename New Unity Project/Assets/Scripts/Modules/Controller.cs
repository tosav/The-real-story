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
	public float delayTimer= 2000f;
	float timer;

    private void Start()
    {
        switch (GameManager.instance.GameLevel)
        {
            case 1:
                delayTimer = 0;
                break;
            case 2:
                delayTimer = 0;
                break;
            case 3:
                delayTimer = 0;
                break;
            default:
                delayTimer = 0;
                break;
        }
        Build = new GameObject[Building.GetComponent<Building>().buildings.Length];//количество игровых обьектов на поле
        Build[0] = Building;
        Build[0].GetComponent<Building>().c=this;
        Build[0].GetComponent<Building>().i = 0;
        Bul.GetComponent<Building>().buildings = Building.GetComponent<Building>().buildings;
		timer = delayTimer;
		enemy.GetComponent<Enemy_event>().repeat= Build[0].GetComponent<Building>().repeat;
        enemy.SetActive(false);
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
            GameManager.instance.LevelPassed();
			Building.GetComponent<Building>().repeat.GetComponent<ScrollMenu>().speedY = 10f;
			Building.GetComponent<Building>().nextlevel.GetComponent<ScrollMenu>().speedY = 10f;
        }
    }
    private void OnMouseDown()
    {
        if (GameManager.instance.GameStarted)
        {
            Build[i].GetComponent<Rigidbody2D>().gravityScale = 9.8f;
        }
    }
	private void Update()//тут будут рождаться враги
	{

        if (GameManager.instance.GameStarted && delayTimer!=0)
        {

            timer -= Time.deltaTime;
            if (timer <= 0 & Building.GetComponent<Building>().repeat.GetComponent<ScrollMenu>().speedY != 10f)
            {
                    timer = delayTimer;
                    GameObject en = Instantiate(enemy);
                    en.SetActive(true);
            }
        }
	}
}
