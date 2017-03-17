using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public GameObject buttons;
    public Text gameName;
	public GameObject earth;
	public GameObject gamebuttons;
	public AudioClip hit;
	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource> ();
	}

    private void OnMouseDown()
    {
		gameName.GetComponent<ScrollMenu>().speed = 10f;
		gameName.GetComponent<ScrollMenu>().checkPosY = 100f;
        buttons.GetComponent<ScrollMenu>().speed = -10f;
        buttons.GetComponent<ScrollMenu>().checkPosY = -200f;
		earth.GetComponent<ScrollMenu>().speed = -10f;
		earth.GetComponent<ScrollMenu>().checkPosY = -400f;
        gamebuttons.GetComponent<ScrollMenu>().speed = 10f;
        gamebuttons.GetComponent<ScrollMenu>().checkPosY = 0;
        // Game g = new Game();
        LoadSave.Load();
		source.PlayOneShot (hit);
    }
}
