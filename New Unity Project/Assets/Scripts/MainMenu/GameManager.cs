using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
    private AppPaused pause;
	void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        // pause = new AppPaused();
        if (!PlayerPrefs.HasKey("coin"))
            PlayerPrefs.SetInt("coin", 5);
        if (!PlayerPrefs.HasKey("lives"))
            PlayerPrefs.SetInt("lives", 5);

    }
    
    public void PlayerCollided() {
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives")-1);
    }
    void pauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        AudioListener.volume = 0.0f;//set volume audio
        Debug.Log("paused..");
    }

    void resumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        AudioListener.volume = 1; //set audio volume
        Debug.Log("resumed..");
    }
    void Update()
    {
        //это чтоб если вышли из игры не играла музыка
        //Create condition
        /*if (pause.IsPaused != AudioListener.pause)
        {
            if (pause.IsPaused)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }*/
    }
}
