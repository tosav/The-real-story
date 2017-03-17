using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
	public AudioClip hit;
	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource> ();
	}
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        String name = "Level" + Convert.ToString(Convert.ToInt32(SceneManager.GetActiveScene().name.Replace("Level", "")) + 1);
		SceneManager.LoadScene(name);
		source.PlayOneShot (hit);
    }
}
