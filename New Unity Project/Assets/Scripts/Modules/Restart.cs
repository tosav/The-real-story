using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour { 

	public AudioClip hit;
	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource> ();
	}
    private void OnMouseDown()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		source.PlayOneShot (hit);
    }
}
