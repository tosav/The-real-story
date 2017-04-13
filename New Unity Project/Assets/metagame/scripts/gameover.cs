using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour {
	
	int i=0;
	
	void Update () 
	{
       
	   int ch = PlayerPrefs.GetInt("ch");
       int era = PlayerPrefs.GetInt("era");
	  

        if (era == 4 && ch == 4 &&  i <= 1)
        {
            GameObject.Find("квадрат").GetComponent<Animation>().Play("gameover");
			i++;
        }
             
    }

}
