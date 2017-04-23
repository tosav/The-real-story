using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject buttons;
    public Text GameName;
	public GameObject Earth;
    GameObject menu;
    private void Awake()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
    }
    private void OnMouseDown()
    {
		GameName.GetComponent<ScrollMenu>().speedY = 10f;
        GameName.GetComponent<ScrollMenu>().checkPosY = 130f;
		buttons.GetComponent<ScrollMenu>().speedY = -10f;
        buttons.GetComponent<ScrollMenu>().checkPosY = -200f;
		Earth.GetComponent<ScrollMenu>().speedY = -10f;
        Earth.GetComponent<ScrollMenu>().checkPosY = -400f;
        menu.GetComponent<ScrollMenu>().speedY = 10;
        menu.GetComponent<ScrollMenu>().checkPosY = 0f;
    }
}
