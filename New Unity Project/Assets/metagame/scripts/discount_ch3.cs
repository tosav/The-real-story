using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class discount_ch3 : MonoBehaviour {

    public String[] money;
    Int32 era;
    Int32 ob_m;
    Int32 ch_m;
    Int32 v_sum;
    public GameObject textik;
	int i=0;
	string s;
	

	void Update ()
    {
		era=PlayerPrefs.GetInt("era");
        
	    ob_m=PlayerPrefs.GetInt("money");
		
		if (era<=4) {textik.GetComponent<Text>().text = money[era];}
		else {textik.GetComponent<Text>().text = money[era-1];}
        

       if (era<=4) { ch_m = Convert.ToInt32(money[era]);}
	   
	   s=PlayerPrefs.GetString("save3");
	   v_sum = ob_m - ch_m;
	   				if (v_sum<0){
					PlayerPrefs.SetString("buy3", "false");}
					else {PlayerPrefs.SetString("buy3", "true");}
	   
    }

    void OnMouseUp()
    {
        if (i<=4 && s!="true" )
		{		//v_sum = ob_m - ch_m;		
				if (v_sum >= 0)
				{
					PlayerPrefs.SetInt("money",  v_sum);
			
				}
				//if (v_sum<0){
				//PlayerPrefs.SetString("buy4", "false");
		//}
				i++;
		}

    }
}
