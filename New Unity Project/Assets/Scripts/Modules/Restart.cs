using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour { 

	public AudioClip hit;
    
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<ScrollMenu>().speedY = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GetComponent<AudioSource>().PlayOneShot (hit);
    }
}
