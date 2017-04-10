using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class discount : MonoBehaviour {

    public String[] money;
    Int32 era;
    Int32 ob_m;
    Int32 ch_m;
    Int32 v_sum;
    public GameObject textik;
	public static bool buy=true;

    void Start ()
    {

    }

	void Update ()
    {
		era=PlayerPrefs.GetInt("era");
        
	    ob_m=PlayerPrefs.GetInt("money");
		
		if (era<=4) {textik.GetComponent<Text>().text = money[era];}
		else {textik.GetComponent<Text>().text = money[era-1];}
        

        ch_m = Convert.ToInt32(money[era]);
		
    }

    void OnMouseUp()
    {

        v_sum = ob_m - ch_m;
        
		if (v_sum >= 0)
        {
		  PlayerPrefs.SetInt("money",  v_sum);
			buy=true;
			
        }
        else
        {
			PlayerPrefs.SetInt("money", 0);
			buy=false;
        }

    }
}
