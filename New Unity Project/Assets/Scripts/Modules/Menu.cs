using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour { 

	public AudioClip hit;
	AudioSource source;
    public GameObject buttons;
    public Text gameName;
    public GameObject menubutton;

    void Start()
	{
		source = GetComponent<AudioSource> ();
	}
    private void OnMouseDown()
    {
        source.PlayOneShot(hit);
        gameName.GetComponent<ScrollMenu>().speedY = -10f;
        gameName.GetComponent<ScrollMenu>().checkPosY = 0f;
        buttons.GetComponent<ScrollMenu>().speedY = 10f;
        buttons.GetComponent<ScrollMenu>().checkPosY = 0f;
        menubutton.GetComponent<ScrollMenu>().speedY = -10f;
        menubutton.GetComponent<ScrollMenu>().checkPosY = -200;
        GameManager.instance.EnterMenu();
    }
}
