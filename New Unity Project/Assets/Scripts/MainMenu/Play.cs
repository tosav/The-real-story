using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public GameObject buttons;
    public Text gameName;
	public GameObject menubutton;
	public AudioClip hit;
	public GameObject light;
	public GameObject gameLight;
	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource> ();
	}

    private void OnMouseDown()
	{
		source.PlayOneShot (hit);
		gameName.GetComponent<ScrollMenu>().speedY = 10f;
		gameName.GetComponent<ScrollMenu>().checkPosY = 100f;
		buttons.GetComponent<ScrollMenu>().speedY = -10f;
        buttons.GetComponent<ScrollMenu>().checkPosY = -200f;
		menubutton.GetComponent<ScrollMenu>().speedY = 10f;
		menubutton.GetComponent<ScrollMenu>().checkPosY = 0;
        // Game g = new Game();
		GameManager.instance.EnterGame ();
		light.SetActive (false);
		gameLight.SetActive (true);
    }
}
