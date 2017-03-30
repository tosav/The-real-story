using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
    public GameObject menuLight;
    public GameObject gameLight;

    [SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject mainCamera;

	private bool playerActive = false;//
	private bool gameOver = false;//проигрыш
	private bool gameStarted = false;//игра в процессе
	private int gameLevel=1;//уровень игры
    private AppPaused pause;
    public bool PlayerActive {
		get { return playerActive; }
	}
	public int GameLevel {
		get { return gameLevel; }
	}
	public bool GameOver {
		get { return gameOver; }
	}

	public bool GameStarted {
		get { return gameStarted; }
	}

	void Awake() {
		if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
        }
        pause = new AppPaused();
        Assert.IsNotNull(mainMenu);
        mainMenu.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		EnterMenu ();
	}

	public void PlayerCollided() {
		gameOver = true;
        gameStarted = false;
        Game.current.Lives -=1;
	}

	public void PlayerStartedGame() {
		playerActive = true;
	}

	public void EnterGame()
    {
        menuLight.SetActive(false);
        gameLight.SetActive(true);
        mainMenu.SetActive (false);
		mainCamera.SetActive (true);
		gameStarted = true;
	}
	public void EnterMenu() {
        
        mainMenu.SetActive (true);
        mainCamera.SetActive(false);
        menuLight.SetActive(true);
        gameLight.SetActive(false);
        gameStarted = false;

        //ну и тип сохранялки надо наверно и проверки
    }
	public void LevelPassed(){
		gameLevel++;
        gameStarted = false;
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
        //Create condition
        if (pause.IsPaused != AudioListener.pause)
        {
            if (pause.IsPaused)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }
    }
}
