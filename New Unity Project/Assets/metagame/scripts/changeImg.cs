using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class changeImg : MonoBehaviour
{

    public Sprite[] buildings0;
    public int era=0;
    public int ch=0;
    public bool vr = true;
   // RaycastHit2D hit;
  //  bool isTouched;
    public GameObject[] one;
    public GameObject prefab;
    string str_ch;
    string str_era;
    Color32 color;

    void Start()
    {

        FileInfo f = new FileInfo("Assets/metagame/file/ch.txt");
        FileInfo f1 = new FileInfo("Assets/metagame/file/era.txt");
        //----------------------------------------------------------

        p_ch();//считываем кол-во активных элементов
        p_era();//считываем эру

        era = Convert.ToInt32(str_era);
        ch = Convert.ToInt32(str_ch);
      
        ChangeImg();

        //здесь мы должны просматривать был ли уже нажат какой-либо предмет 
        //если да, то сделать vr=false и заливку серым цветом

       // isTouched = false;
        color = gameObject.GetComponent<Image>().color;//запоминаем цвет активного элемента
    }

    void Update()
    {
        p_ch();//считываем кол-во активных элементов
        p_era();//считываем эру
        era = Convert.ToInt32(str_era);
        ch = Convert.ToInt32(str_ch);
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

       if (vr == true)
       {   
           ChangeColor();
           ch = ch + 1;
           str_ch = Convert.ToString(ch);
           v_ch();
           Destroy(prefab);
           prefab = Instantiate(one[era]);//, new Vector3(189, 307, 0), Quaternion.identity);
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