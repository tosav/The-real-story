using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject mainCamera;

	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;
	private int gameLevel=0;
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

	public void EnterGame() {
		print("вроде защел");
		mainMenu.SetActive (false);
		mainCamera.SetActive (true);
		gameStarted = true;
	}
	public void EnterMenu() {
		mainMenu.SetActive (true);
	}
	public void LevelPassed(){
		gameLevel++;
		Game.current.Level = gameLevel;
	}
}
