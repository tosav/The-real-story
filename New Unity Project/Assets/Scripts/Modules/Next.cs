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
        SceneManager.LoadScene("Level"+(Convert.ToInt32(SceneManager.GetActiveScene().name.Substring(5))+1));
        //сохранение очков

        GetComponent<AudioSource>().PlayOneShot (hit);
    }
}
