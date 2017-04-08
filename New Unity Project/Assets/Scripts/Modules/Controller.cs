using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    public GameObject Building;
    public GameObject Bul;
    private GameObject[] Build;
    public GameObject enemy;
    public GameObject text;
	private int i = 0;
	public float delayTimer= 2000f;
    public int count=4;
	float timer;

    public int BuildCount
    {
        get { return count; }

        set { count=value; }
    }
    private void Awake()
    {
        //это плохая идея связывать их по тегам
        //text= GameObject.FindGameObjectWithTag("Text");
        Build = new GameObject[count];//количество игровых обьектов на поле
        Build[0] = Building;
        Build[0].GetComponent<Building>().i = 0;
        Bul.GetComponent<Building>().buildings = Building.GetComponent<Building>().buildings;
        timer = delayTimer;
        enemy.GetComponent<Enemy_event>().repeat = Build[0].GetComponent<Building>().repeat;
        enemy.SetActive(false);
        text.GetComponent<Text>().text = count.ToString();
    }
    private void Start()
    {
    }

    public void State()
    {
        count--;
        text.GetComponent<Text>().text = count.ToString();
        if (count == 0)
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            Building.GetComponent<Building>().repeat.GetComponent<ScrollMenu>().speedY = 10f;
            Building.GetComponent<Building>().next.GetComponent<ScrollMenu>().speedY = 10f;
        }
        else if (count>0)
        {
            Build[i + 1] = Instantiate(Bul);
            Build[i + 1].GetComponent<Building>().i = (i + 1)% Build[i + 1].GetComponent<Building>().buildings.Length;
            Build[i + 1].GetComponent<Building>().next = Build[0].GetComponent<Building>().next;
            Build[i + 1].GetComponent<Building>().repeat = Build[0].GetComponent<Building>().repeat;
            Build[i + 1].GetComponent<Building>().boom = Build[0].GetComponent<Building>().boom;
            Build[i + 1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
            i ++;
        }
    }
    private void OnMouseDown()
    {
        if (Build[i])
        Build[i].GetComponent<Building>().gravity=9.8f;
    }
	private void Update()//тут будут рождаться враги
	{
        if (delayTimer!=0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 & Building && Building.GetComponent<Building>().repeat.GetComponent<ScrollMenu>().speedY != 10f)
            {
                    timer = delayTimer;
                    GameObject en = Instantiate(enemy);
                    en.SetActive(true);
            }
        }
	}
}
