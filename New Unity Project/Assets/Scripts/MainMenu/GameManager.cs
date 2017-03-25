using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
    public GameObject light;
    public GameObject gameLight;

    [SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject mainCamera;

	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;
	private int gameLevel=1;
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
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		Assert.IsNotNull (mainMenu);
		mainMenu.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		EnterMenu ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void PlayerCollided() {
		gameOver = true;
		Game.current.Lives -=1;
	}

	public void PlayerStartedGame() {
		playerActive = true;
	}

	public void EnterGame()
    {
        light.SetActive(false);
        gameLight.SetActive(true);
        mainMenu.SetActive (false);
		mainCamera.SetActive (true);
		gameStarted = true;
	}
	public void EnterMenu() {
		mainMenu.SetActive (true);
        mainCamera.SetActive(false);
        light.SetActive(true);
        gameLight.SetActive(false);
        gameStarted = false;
        //ну и тип сохранялки надо наверно и проверки
    }
	public void LevelPassed(){
		gameLevel++;
		Game.current.Level = gameLevel;
	}
}
