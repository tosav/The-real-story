using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public GameObject buttons;
    public Text gameName;
	public AudioClip hit;
	AudioSource source;
    void Awake()
    {
    }
    void Start()
	{
		source = GetComponent<AudioSource> ();
    }

    private void OnMouseDown()
    {
        if (!PlayerPrefs.HasKey("level"))
            PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("level"));
        GetComponent<AudioSource>().Play();
        gameName.GetComponent<ScrollMenu>().speedY = 10f;
		gameName.GetComponent<ScrollMenu>().checkPosY = 100f;
		buttons.GetComponent<ScrollMenu>().speedY = -10f;
        buttons.GetComponent<ScrollMenu>().checkPosY = -200f;
        source.PlayOneShot(hit);
    }
}
