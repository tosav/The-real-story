using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GoogleMobileAds.Api;

public class LoadSave : MonoBehaviour {
    public static Game savedGame = new Game();
    private const string banner = "ca-app-pub-2129853974374124~3225831096";
    void Start()
    {
        BannerView bannerv = new BannerView(banner, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerv.LoadAd(request);
    }
    public static void Save()
    {
        PlayerPrefs.SetInt("Level", Game.current.level);
    }
    public static void Load()
    {
        if (PlayerPrefs.HasKey("Level"))
            Game.current.level = PlayerPrefs.GetInt("Level");
        else
        {
            Game.current.level = 0;
            PlayerPrefs.SetInt("Level", Game.current.level);
        }
    }
}