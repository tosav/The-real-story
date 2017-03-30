using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
	public AudioClip hit;
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        GameManager.instance.LevelPassed();
        GetComponent<AudioSource>().PlayOneShot (hit);
    }
}
