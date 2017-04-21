using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meta : MonoBehaviour
{
    private void Awake()
    {
       GameObject back = GameObject.FindGameObjectWithTag("Back");
        MobileAdsScript scr = back.GetComponent<MobileAdsScript>();
        scr.RequestBanner();
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("metagame");
    }
}
