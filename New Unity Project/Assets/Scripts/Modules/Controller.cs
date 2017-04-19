using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Analytics;

public class Controller : MonoBehaviour {
    public GameObject Building;
    public GameObject Bul;
    private List<GameObject> Build;
    public GameObject enemy;
    public GameObject text;
	private int i = 0;
	public float delayTimer= 2000f;
    public int count=4;
	float timer;

    public const int MaxVolumeValue = 6;
    private int musicVolume = 0;
    public int MusicVolume {
      get {
        return musicVolume;
      }
      set {
        musicVolume = value;
        PlayerPrefs.SetInt(StringConstants.MusicVolume, musicVolume);
        // Music volume is controlled on the music source, which is set to
        // ignore the volume settings of the listener.
        Controller c = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
        c.GetComponentInChildren<AudioSource>().volume = (float)musicVolume / MaxVolumeValue;
      }
    }
    private int soundFxVolume = 0;
    public int SoundFxVolume {
      get {
        return soundFxVolume;
      }
      set {
        soundFxVolume = value;
        PlayerPrefs.SetInt(StringConstants.SoundFxVolume, soundFxVolume);
        // Sound effect volumes are controlled by setting the listeners volume,
        // instead of each effect individually.
        AudioListener.volume = (float)soundFxVolume / MaxVolumeValue;
      }
    }

    public int BuildCount
    {
        get { return count; }

        set { count=value; }
    }
    private void Awake()
    {
        Build = new List<GameObject>();
        //это плохая идея связывать их по тегам
        //text= GameObject.FindGameObjectWithTag("Text");
        Build.Add(Building);
        Build[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Build[0].GetComponent<Building>().i = 0;
        Bul.GetComponent<Building>().buildings = Building.GetComponent<Building>().buildings;
        timer = delayTimer;
        enemy.GetComponent<Enemy_event>().repeat = Build[0].GetComponent<Building>().repeat;
        enemy.SetActive(false);
        text.GetComponent<Text>().text = count.ToString();
    }
    public void DecCount()
    {
        count++;
        text.GetComponent<Text>().text = count.ToString();
    }

    private void Start()
    {
        Firebase.Analytics.Parameter[] LevelStartParameters = {
  new Firebase.Analytics.Parameter(
    Firebase.Analytics.FirebaseAnalytics.ParameterLevel, PlayerPrefs.GetInt("level")),
  new Firebase.Analytics.Parameter("dateStart", DateTime.Now.ToString()),
  new Firebase.Analytics.Parameter("NumAttempt", PlayerPrefs.GetInt("attempt"))
};
        Firebase.Analytics.FirebaseAnalytics
          .LogEvent("LevelStart", LevelStartParameters);
        InitializeFirebaseAndStart();
    }
    void InitializeFirebaseAndStart()
    {
        Firebase.DependencyStatus dependencyStatus = Firebase.FirebaseApp.CheckDependencies();

        if (dependencyStatus != Firebase.DependencyStatus.Available)
        {
            Firebase.FirebaseApp.FixDependenciesAsync().ContinueWith(task => {
                dependencyStatus = Firebase.FirebaseApp.CheckDependencies();
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    InitializeFirebaseComponents();
                }
                else
                {
                    Debug.LogError(
                        "Could not resolve all Firebase dependencies: " + dependencyStatus);
                    Application.Quit();
                }
            });
        }
        else
        {
            InitializeFirebaseComponents();
        }
    }

    void InitializeFirebaseComponents()
    {
        InitializeAnalytics();

        System.Threading.Tasks.Task.WhenAll(
            //InitializeRemoteConfig()
          ).ContinueWith(task => { StartGame(); });
    }
   /* System.Threading.Tasks.Task InitializeRemoteConfig()
    {
        Dictionary<string, object> defaults = new Dictionary<string, object>();
        

        Firebase.RemoteConfig.FirebaseRemoteConfig.SetDefaults(defaults);
        return Firebase.RemoteConfig.FirebaseRemoteConfig.FetchAsync(System.TimeSpan.Zero);
    }*/
    void InitializeAnalytics()
    {
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

        // Set the user's sign up method.
        FirebaseAnalytics.SetUserProperty(
          FirebaseAnalytics.UserPropertySignUpMethod,
          "Google");

        // TODO(ccornell): replace this with a real user token
        // once Auth gets hooked up.
        // Set the user ID.
        FirebaseAnalytics.SetUserId("desktop_user");
    }
    void StartGame()
    {
        // Remote Config data has been fetched, so this applies it for this play session:
        
        Firebase.AppOptions ops = new Firebase.AppOptions();
        CommonData.app = Firebase.FirebaseApp.Create(ops);

        Screen.orientation = ScreenOrientation.Portrait;
        

        // Set up volume settings.
        MusicVolume = PlayerPrefs.GetInt(StringConstants.MusicVolume, MaxVolumeValue);
        // Set the music to ignore the listeners volume, which is used for sound effects.
        CommonData.mainCamera.GetComponentInChildren<AudioSource>().ignoreListenerVolume = true;
        SoundFxVolume = PlayerPrefs.GetInt(StringConstants.SoundFxVolume, MaxVolumeValue);
        
    }
    void InitializeFirebase()
    {
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

        // Set the user's sign up method.
        FirebaseAnalytics.SetUserProperty( FirebaseAnalytics.UserPropertySignUpMethod, "Google"); //инициализация с поомщью гугла
        // Set the user ID.
        FirebaseAnalytics.SetUserId("1");
    }
    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
    {
        Debug.Log("Received Registration Token: " +token.Token);
    }

    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
        Debug.Log("Received a new message from: " +e.Message.From);
    }
    public void AnaliticsAPP_OPEN()
    {

    }
    public void AnalyticsLogin()
    {
        // Log an event with no parameters.
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLogin);
    }

    public void AnalyticsProgress()
    {
        // Log an event with a float.
        FirebaseAnalytics.LogEvent("progress", "percent", 0.4f);
    }

    public void AnalyticsScore()
    {
        // Log an event with an int parameter.
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventPostScore, FirebaseAnalytics.ParameterScore, 42);
    }
    public void AnaliticsLevelEnd()
    {

    }
    public void AnalyticsLevelUp()
    {
        PlayerPrefs.SetInt("level", Convert.ToInt32(SceneManager.GetActiveScene().name.Substring(5)) + 1);
        FirebaseAnalytics.LogEvent( FirebaseAnalytics.EventLevelUp, new Parameter(FirebaseAnalytics.ParameterLevel, PlayerPrefs.GetInt("level")));
    }
    public void State()
    {
        count--;
        text.GetComponent<Text>().text = count.ToString();
        if (count == 0)
        {

            Firebase.Analytics.Parameter[] LevelPassParameters = {
            new Firebase.Analytics.Parameter(
            Firebase.Analytics.FirebaseAnalytics.ParameterLevel, PlayerPrefs.GetInt("level")),
            new Firebase.Analytics.Parameter("dateEnd", DateTime.Now.ToString()),
            new Firebase.Analytics.Parameter("NumAttempt", PlayerPrefs.GetInt("attempt"))
            };
            Firebase.Analytics.FirebaseAnalytics
              .LogEvent("LevelPassed", LevelPassParameters);
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            Building.GetComponent<Building>().repeat.GetComponent<ScrollMenu>().speedY = 10f;
            Building.GetComponent<Building>().next.GetComponent<ScrollMenu>().speedY = 10f;
        }
        else if (count>0)
        {

            Firebase.Analytics.Parameter[] LevelPassParameters = {
            new Firebase.Analytics.Parameter(
            Firebase.Analytics.FirebaseAnalytics.ParameterLevel, PlayerPrefs.GetInt("level")),
            new Firebase.Analytics.Parameter("dateOver", DateTime.Now.ToString()),
            new Firebase.Analytics.Parameter("NumAttempt", PlayerPrefs.GetInt("attempt"))
            };
            Firebase.Analytics.FirebaseAnalytics
              .LogEvent("LevelOver", LevelPassParameters);
            GameObject gm = Instantiate(Bul);
            PlayerPrefs.SetInt("attempt", PlayerPrefs.GetInt("attempt")+1);
            Build.Add(gm);
            Build[i + 1].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Build[i + 1].GetComponent<Building>().i = (i + 1)% Build[i + 1].GetComponent<Building>().buildings.Length;
            Build[i + 1].GetComponent<Building>().next = Build[0].GetComponent<Building>().next;
            Build[i + 1].GetComponent<Building>().repeat = Build[0].GetComponent<Building>().repeat;
            Build[i + 1].GetComponent<Building>().boom = Build[0].GetComponent<Building>().boom;
            Build[i + 1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
            i ++;
        }
    }
    public GameObject gmObject
    {
        get { return Build[i]; }
    }
    private void OnMouseDown()
    {
        if (GameObject.Find("cursor"))
        {
            Destroy(GameObject.Find("cursor"));
            Destroy(GameObject.Find("attention"), GameObject.Find("attention").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);
            Destroy(GameObject.Find("Arrows"), 3f);
        }

        if (Build[i])
        {
            Build[i].GetComponent<Building>().gravity = 9.8f;
            Build[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
	private void Update()//тут будут рождаться враги
	{
        if (delayTimer!=0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 & Building && Building.GetComponent<Building>().repeat.GetComponent<ScrollMenu>().speedY != 10f)
            {
                    timer = delayTimer;
                    GameObject en = Instantiate(enemy);
                    en.SetActive(true);
            }
        }
	}
}