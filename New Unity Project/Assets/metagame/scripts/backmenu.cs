using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backmenu : MonoBehaviour {
    private void Awake()
    {
        Controller c = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
        MobileAdsScript scr = c.GetComponent<MobileAdsScript>();
        scr.DestroyBannerRect();
    }
	void OnMouseUp()
	{
	SceneManager.LoadScene("main");
	}
}
