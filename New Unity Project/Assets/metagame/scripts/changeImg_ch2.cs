using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
public class changeImg_ch2 : MonoBehaviour
{

    public Sprite[] buildings0;
    public int era = 0;
    public int ch = 0;
    public bool vr = true;
    // RaycastHit2D hit;
    //  bool isTouched;
    public GameObject[] one;
    public GameObject prefab;
    string str_ch;
    string str_era;
    Color32 color;
    public bool buy;
    string str_m, str_sum;
    Int32 ob_m;
	public String[] money;
    Int32 ch_m;
    Int32 v_sum;
    public GameObject textik;

    void Start()
    {

        FileInfo f = new FileInfo("Assets/metagame/file/ch.txt");
        FileInfo f1 = new FileInfo("Assets/metagame/file/era.txt");
        FileInfo f2 = new FileInfo("Assets/metagame/file/money.txt");
        //----------------------------------------------------------

        p_ch();//считываем кол-во активных элементов
        p_era();//считываем эру

        era = Convert.ToInt32(str_era);
        ch = Convert.ToInt32(str_ch);

        ChangeImg();
        color = gameObject.GetComponent<Image>().color;//запоминаем цвет активного элемента

        //здесь мы должны просматривать был ли уже нажат какой-либо предмет 
        //если да, то сделать vr=false и заливку серым цветом

        if (PlayerPrefs.GetString("save2") == "true")
        {
            ChangeColor();
            vr = false;
            prefab = Instantiate(one[era]);
        }
        else { gameObject.GetComponent<Image>().color = color;
            if (era > 0) { prefab = Instantiate(one[era - 1]); }
        }


        // isTouched = false;  
    }

    void Update()
    {

        p_ch();//считываем кол-во активных элементов
        p_era();//считываем эру
        p_money();//считываем колличество денюжек
        era = Convert.ToInt32(str_era);
        ch = Convert.ToInt32(str_ch);
        ob_m = Convert.ToInt32(str_m);

        textik.GetComponent<Text>().text = money[era];//задаем цены на наш товар

        ch_m = Convert.ToInt32(money[era]);

        if (Input.GetMouseButtonDown(2))//сброс сохранения
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }


    void FixedUpdate()
    {


        if (ch == 4)
        {
            newEra();
            ChangeImg();
            gameObject.GetComponent<Image>().color = color;
        }
    }

    void OnMouseUp()
    {

		v_sum = ob_m - ch_m;
        if (v_sum >= 0)
        {
            str_sum = Convert.ToString(v_sum);
            v_money();
			buy = true;
        }
        else
        {
            //str_sum = "0";
           // v_money();
			buy = false;
        }
		
        if (vr == true) if (buy == true)
        {
            ChangeColor();
            ch = ch + 1;
            str_ch = Convert.ToString(ch);
            v_ch();
            Destroy(prefab);
            prefab = Instantiate(one[era]);//, new Vector3(189, 307, 0), Quaternion.identity);
            PlayerPrefs.SetString("save2", "true");
            PlayerPrefs.Save();
        }
        vr = false;
		

    }


    void ChangeImg()
    {
        gameObject.GetComponent<Image>().sprite = buildings0[era];
    }

    void ChangeColor()
    {
        gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
    }

    void newEra()
    {
        era = era + 1;
        str_era = Convert.ToString(era);
        v_era();
        ch = 0;
        str_ch = Convert.ToString(ch);
        v_ch();
        
       // PlayerPrefs.DeleteKey("save1");
        PlayerPrefs.SetString("save2", "false");
        PlayerPrefs.Save();
        vr = true;
    }

    void v_ch()
    {
        StreamWriter sw = new StreamWriter("Assets/metagame/file/ch.txt");
        sw.WriteLine(str_ch);
        sw.Close();
    }

    void v_era()
    {
        StreamWriter sw = new StreamWriter("Assets/metagame/file/era.txt");
        sw.WriteLine(str_era);
        sw.Close();
    }

    void p_ch()
    {
        StreamReader sr = new StreamReader("Assets/metagame/file/ch.txt");
        str_ch = "";
        while (!sr.EndOfStream)
        {
            str_ch += sr.ReadLine();
            //str += "";
        }
        sr.Close();
    }

    void p_era()
    {
        StreamReader sr1 = new StreamReader("Assets/metagame/file/era.txt");
        str_era = "";
        while (!sr1.EndOfStream)
        {
            str_era += sr1.ReadLine();
            // str1 += "";
        }
        sr1.Close();
    }


    public void p_money()
    {
        StreamReader sr1 = new StreamReader("Assets/metagame/file/money.txt");
        str_m = "";
        while (!sr1.EndOfStream)
        {
            str_m += sr1.ReadLine();
        }
        sr1.Close();
    }
	
	
    public void v_money()
    {
        StreamWriter sw = new StreamWriter("Assets/metagame/file/money.txt");
        sw.WriteLine(str_sum);
        sw.Close();
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