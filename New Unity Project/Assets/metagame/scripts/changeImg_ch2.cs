using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;


public class changeImg_ch2 : MonoBehaviour
{
    public Sprite[] buildings0;
    public int era;
    public int ch;
    public bool vr = true;
    Ray ray;
    RaycastHit hit;
    public GameObject[] one;
    public GameObject prefab;
    public bool isPC;
    Color32 color;
	string buy;

    void Start()
    {

	   if(PlayerPrefs.HasKey("ch")==true && PlayerPrefs.HasKey("era")==true ) 
	   { 
			ch=PlayerPrefs.GetInt("ch");
			era=PlayerPrefs.GetInt("era");
		} 
		else
		{
			PlayerPrefs.SetInt("ch", 0);
			PlayerPrefs.SetInt("era", 0);
			ch=PlayerPrefs.GetInt("ch");
			era=PlayerPrefs.GetInt("era");
		}
               
	  
        ChangeImg();
        color = gameObject.GetComponent<Image>().color;//запоминаем цвет активного элемента

        
        //если да, то сделать vr=false и заливку серым цветом

		if (PlayerPrefs.GetString("save2") == "true" )//здесь мы должны просматривать был ли уже нажат какой-либо предмет  //если да, то сделать vr=false и заливку серым цветом
        {if (era<=4){
            ChangeColor();
            vr = false;
			prefab = Instantiate(one[era]);}
		else{
			ChangeColor();
            vr = false;
			prefab = Instantiate(one[era-1]);}
        }
        else { gameObject.GetComponent<Image>().color = color;
            if (era > 0) { prefab = Instantiate(one[era - 1]); }
        }
       //  isTouched = false;  
    }

    void Update()
    {
	  		ch=PlayerPrefs.GetInt("ch");
			era=PlayerPrefs.GetInt("era");
			buy=PlayerPrefs.GetString("buy2");
        
        if (Input.GetMouseButtonDown(2))//сброс сохранения
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
       /* if (!isPC)
        { 

            Touch touch = Input.GetTouch(0);
            ray = Camera.main.ScreenPointToRay(touch.position);
            if( Input.touchCount > 0)
            {
                if (Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject == prefab)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        Vector3 cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
                        prefab.transform.position = Camera.main.ScreenToWorldPoint( new Vector3(touch.position.x, touch.position.y, cameraTransform.z));
                    }
                }
            }
        }

        if (isPC)
        {

                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Input.GetMouseButton(0))
                {
                    if (Physics.Raycast(ray, out hit, 100) && hit.collider.gameObject == prefab)
                    {
                        Vector3 cameraTransform = Camera.main.transform.InverseTransformPoint(0, 0, 0);
                    prefab.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraTransform.z));
                    }
                }
        }  */  
    }

    void FixedUpdate()
    {
        if (ch == 4 && era<4)//новая эра
        {
            newEra();
            ChangeImg();
            gameObject.GetComponent<Image>().color = color;
        }
    }

    void OnMouseUp()
    {
 
        if (vr == true  && ch<=4 && era<=4 && buy!="false")
        {
            ChangeColor();
            ch = ch + 1;
		   	PlayerPrefs.SetInt("ch", ch);
            Destroy(prefab);
            prefab = Instantiate(one[era]);//, new Vector3(189, 307, 0), Quaternion.identity);
            PlayerPrefs.SetString("save2", "true");
            PlayerPrefs.Save();
        }
        vr = false;
		
	}

    void ChangeImg()
    {
		if (era<=4){
        gameObject.GetComponent<Image>().sprite = buildings0[era];}
		else {gameObject.GetComponent<Image>().sprite = buildings0[era-1];}
    }

    void ChangeColor()
    {
        gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
    }

    void newEra()
    {
        era = era + 1;
	    PlayerPrefs.SetInt("era", era);
        ch = 0;
		PlayerPrefs.SetInt("ch", ch);
        
        PlayerPrefs.SetString("save2", "false");
        PlayerPrefs.Save();
        vr = true;
    }

    }