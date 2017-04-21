using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backmenu : MonoBehaviour {
    private void Awake()
    {
        GameObject back = GameObject.FindGameObjectWithTag("Back");
        MobileAdsScript scr = back.GetComponent<MobileAdsScript>();
        scr.DestroyBannerRect();
    }
	void OnMouseUp()
	{
	SceneManager.LoadScene("main");
	}
}
