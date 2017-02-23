using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour {

    public GameObject obj;
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable
    void Start ()
    {
        guiStyle.fontSize = 20; //change the font size
        GUILayout.Label("Write your text here.", guiStyle);
    }
    void Update () {
		
	}
}
