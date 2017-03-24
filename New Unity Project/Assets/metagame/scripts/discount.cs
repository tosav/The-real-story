using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class discount : MonoBehaviour {

    public String[] money;
    string str_era;
    string str_m;
    Int32 era;
    Int32 ob_m;
    Int32 ch_m;
    Int32 v_sum;
    string str_sum;
    public GameObject textik;

    void Start ()
    {
        FileInfo f = new FileInfo("Assets/metagame/file/era.txt");
        FileInfo f1 = new FileInfo("Assets/metagame/file/money.txt");
    }

	void Update ()
    {
        p_era();
        era = Convert.ToInt32(str_era);

        p_money();
        ob_m = Convert.ToInt32(str_m);

        textik.GetComponent<Text>().text = money[era];

        ch_m = Convert.ToInt32(money[era]);
    }

    void OnMouseUp()
    {

        v_sum = ob_m - ch_m;
        
		if (v_sum > 0)
        {
            str_sum = Convert.ToString(v_sum);
            v_money();
        }
        else
        {
            str_sum = "0";
            v_money();
        }

    }

    void p_era()
    {
        StreamReader sr = new StreamReader("Assets/metagame/file/era.txt");
        str_era = "";
        while (!sr.EndOfStream)
        {
            str_era += sr.ReadLine();
        }
        sr.Close();
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

}
