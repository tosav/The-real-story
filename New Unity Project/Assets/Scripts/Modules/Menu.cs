using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour { 

	public AudioClip hit;
	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource> ();
	}
    private void OnMouseDown()
    {
        print("Menu");
		SceneManager.LoadScene("main");
		source.PlayOneShot (hit);
    }
}
