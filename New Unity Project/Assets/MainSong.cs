using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSong : MonoBehaviour {
    private static MainSong instance;
    public const int MaxVolumeValue = 6;
    private int musicVolume = 0;
    public int MusicVolume
    {
        get
        {
            return musicVolume;
        }
        set
        {
            musicVolume = value;
            PlayerPrefs.SetInt(StringConstants.MusicVolume, musicVolume);
            // Music volume is controlled on the music source, which is set to
            // ignore the volume settings of the listener.
            gameObject.GetComponentInChildren<AudioSource>().volume = (float)musicVolume / MaxVolumeValue;
        }
    }
    public void Slider_Changed(float value)
    {
        SoundFxVolume = (int) value; 
    }
    private int soundFxVolume = 0;
    public int SoundFxVolume
    {
        get
        {
            return soundFxVolume;
        }
        set
        {
            soundFxVolume = value;
            PlayerPrefs.SetInt(StringConstants.SoundFxVolume, soundFxVolume);
            // Sound effect volumes are controlled by setting the listeners volume,
            // instead of each effect individually.
            AudioListener.volume = (float)soundFxVolume / MaxVolumeValue;
        }
    }
    void Start()
    {
        // Set up volume settings.
        MusicVolume = PlayerPrefs.GetInt(StringConstants.MusicVolume, MaxVolumeValue);
        // Set the music to ignore the listeners volume, which is used for sound effects.
        gameObject.GetComponent<AudioSource>().ignoreListenerVolume = true;
        SoundFxVolume = PlayerPrefs.GetInt(StringConstants.SoundFxVolume, MaxVolumeValue);

    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
