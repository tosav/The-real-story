using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour { 

	public AudioClip hit;
    public GameObject menubutton;
    private void OnMouseDown()
    {
        MobileAdsScript scr = GameObject.FindGameObjectWithTag("Controller").GetComponent<MobileAdsScript>();
        scr.DestroyInterstitial();
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().PlayOneShot(hit);
        menubutton.GetComponent<ScrollMenu>().speedY = -10f;
        menubutton.GetComponent<ScrollMenu>().checkPosY = -200;
        SceneManager.LoadScene("main");
    }
}
