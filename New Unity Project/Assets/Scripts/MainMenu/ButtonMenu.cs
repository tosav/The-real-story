using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour {

    public GameObject buttons;
    public AudioClip hit;
    public Text GameName;
    public GameObject Earth;
    public GameObject menubutton;
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().PlayOneShot(hit);
        GameName.GetComponent<ScrollMenu>().speedY = -10f;
        GameName.GetComponent<ScrollMenu>().checkPosY = 0f;
        buttons.GetComponent<ScrollMenu>().speedY = 10f;
        buttons.GetComponent<ScrollMenu>().checkPosY = 0f;
        Earth.GetComponent<ScrollMenu>().speedY = 10f;
        Earth.GetComponent<ScrollMenu>().checkPosY =0f;
        menubutton.GetComponent<ScrollMenu>().checkPosY = -200f;
        menubutton.GetComponent<ScrollMenu>().speedY = -10f;
    }
}
