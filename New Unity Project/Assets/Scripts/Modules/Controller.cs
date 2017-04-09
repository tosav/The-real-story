using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    public GameObject Building;
    public GameObject Bul;
    private List<GameObject> Build;
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
        Build = new List<GameObject>();
        //это плохая идея связывать их по тегам
        //text= GameObject.FindGameObjectWithTag("Text");
        Build.Add(Building);
        Build[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Build[0].GetComponent<Building>().i = 0;
        Bul.GetComponent<Building>().buildings = Building.GetComponent<Building>().buildings;
        timer = delayTimer;
        enemy.GetComponent<Enemy_event>().repeat = Build[0].GetComponent<Building>().repeat;
        enemy.SetActive(false);
        text.GetComponent<Text>().text = count.ToString();
    }
    public void DecCount()
    {
        count++;
        text.GetComponent<Text>().text = count.ToString();
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
            GameObject gm = Instantiate(Bul);
            Build.Add(gm);
            Build[i + 1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Build[i + 1].GetComponent<Building>().i = (i + 1)% Build[i + 1].GetComponent<Building>().buildings.Length;
            Build[i + 1].GetComponent<Building>().next = Build[0].GetComponent<Building>().next;
            Build[i + 1].GetComponent<Building>().repeat = Build[0].GetComponent<Building>().repeat;
            Build[i + 1].GetComponent<Building>().boom = Build[0].GetComponent<Building>().boom;
            Build[i + 1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
            i ++;
        }
    }
    public GameObject gmObject
    {
        get { return Build[i]; }
    }
    private void OnMouseDown()
    {
        if (GameObject.Find("cursor"))
        {
            Destroy(GameObject.Find("cursor"));
        }
        if (Build[i])
        {
            Build[i].GetComponent<Building>().gravity = 9.8f;
            Build[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
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
