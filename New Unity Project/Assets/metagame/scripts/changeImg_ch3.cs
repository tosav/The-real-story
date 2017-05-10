using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;


public class changeImg_ch3 : MonoBehaviour
{

    public Sprite[] buildings0;
    public int era;
    public int ch;
    public bool vr = true;
    // RaycastHit2D hit;
    //  bool isTouched;
    public GameObject[] one;
    public GameObject prefab;
   // string str_ch;
   // string str_era;
    Color32 color;
	string buy;

    void Start()
    {

       // FileInfo f2 = new FileInfo("Assets/metagame/file/ch.txt");
       // FileInfo f1 = new FileInfo("Assets/metagame/file/era.txt");
        //----------------------------------------------------------

       // p_ch();//считываем кол-во активных элементов
      //  p_era();//считываем эру

      //  era = Convert.ToInt32(str_era);
       // ch = Convert.ToInt32(str_ch);

	   if(PlayerPrefs.HasKey("ch")==true && PlayerPrefs.HasKey("era")==true ) 
	   { 
			//PlayerPrefs.SetInt("ch", 0);
			//PlayerPrefs.SetInt("era", 0);
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

		if (PlayerPrefs.GetString("save3") == "true")//здесь мы должны просматривать был ли уже нажат какой-либо предмет  //если да, то сделать vr=false и заливку серым цветом
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


        // isTouched = false;  
    }

    void Update()
    {  
	  		ch=PlayerPrefs.GetInt("ch");
			era=PlayerPrefs.GetInt("era");
			buy=PlayerPrefs.GetString("buy3");
        
        if (Input.GetMouseButtonDown(2))//сброс сохранения
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
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
 if (PlayerPrefs.HasKey("start") == true){
        if (vr == true && ch<=4 && era<=4 && buy!="false")
        {
            ChangeColor();
            ch = ch + 1;
		   	PlayerPrefs.SetInt("ch", ch);
            Destroy(prefab);
            prefab = Instantiate(one[era]);//, new Vector3(189, 307, 0), Quaternion.identity);
            PlayerPrefs.SetString("save3", "true");
            PlayerPrefs.Save();
        }
        vr = false;
 }
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
        PlayerPrefs.SetString("save3", "false");
        PlayerPrefs.Save();
        vr = true;
    }

  


    /* void touchsomething()
     {

         if (Input.touchCount > 0)
         {
             if (Input.GetTouch(0).phase == TouchPhase.Moved)
             {

                 hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

                 if (hit.collider != null && hit.transform.gameObject.tag == one.name)
                 {
                     isTouched = true;
                 }


                 if (isTouched)
                 {
                     transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5));
                 }

             }
         }

     }*/

    /*foreach (Touch touch in Input.touches)
                  {
                      one.transform.position = touch.position;
                  }

        }*/


}