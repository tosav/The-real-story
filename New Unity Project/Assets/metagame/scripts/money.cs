using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour {

   int money1;
   string m;

    void Start()
    {
	   if(PlayerPrefs.HasKey("money")==true) 
	   { 
			money1=PlayerPrefs.GetInt("money");
			
		} 
		else
		{
			PlayerPrefs.SetInt("money", 100);
			PlayerPrefs.Save();
			money1=PlayerPrefs.GetInt("money");	
		}
    }

    void FixedUpdate()
    {
		money1=PlayerPrefs.GetInt("money");
	    m = Convert.ToString(money1);
        gameObject.GetComponent<Text>().text = m;
		
    }

  
}
