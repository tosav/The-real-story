using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour { 

	public AudioClip hit;
    public GameObject buttons;
    public Text gameName;
    public GameObject menubutton;
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().PlayOneShot(hit);
        gameName.GetComponent<ScrollMenu>().speedY = -10f;
        gameName.GetComponent<ScrollMenu>().checkPosY = 0f;
        buttons.GetComponent<ScrollMenu>().speedY = 10f;
        buttons.GetComponent<ScrollMenu>().checkPosY = 0f;
        menubutton.GetComponent<ScrollMenu>().speedY = -10f;
        menubutton.GetComponent<ScrollMenu>().checkPosY = -200;
        GameManager.instance.EnterMenu();
    }
}
