using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour { 

	public AudioClip hit;

	void Start()
	{
	}
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        new Controller().PlayforRestart();
        GetComponent<AudioSource>().PlayOneShot (hit);
    }
}
