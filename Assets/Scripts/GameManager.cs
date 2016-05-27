using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour {
	
	[SerializeField] private Text _playerTurnText;
	[SerializeField] private Text _winText;
	[SerializeField] private GameObject _gameOverScreen;

	public static GameManager GM { get; private set;}
	public Text PlayerTurnText { 
		get { return _playerTurnText; } 
		private set { _playerTurnText = value; }
	}
	public Text WinText { 
		get { return _winText; } 
		private set { _winText = value; }
	}
	public GameObject GameOverScreen { 
		get { return _gameOverScreen; } 
		private set { _gameOverScreen = value; }
	}
	public Board GameBoard { get; private set;}
	public Side CurrentPlayer { get; private set;}

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
		if (GM == null)
			GM = this.GetComponent<GameManager> ();
		if (GameBoard == null) 
			GameBoard = GameObject.FindGameObjectWithTag ("Board").GetComponent<Board> ();		
		if (PlayerTurnText == null)
			Debug.LogError ("Player turn text not specified.");
		if (GameOverScreen == null)
			Debug.LogError ("GameOverScreen object not specified.");
		if (WinText == null)
			Debug.LogError ("Win text not specified.");
		CurrentPlayer = Side.Black;
		Messenger.AddListener ("NextTurn", EndTurn);
		Messenger.AddListener ("KingDead", EndGame);
	}


	/* --------------- Interface --------------- */

	public void PlayAgain() {
		SceneManager.LoadScene ("prototype"); 
	}

	/* ------------- Other methods ------------- */

	void EndTurn () {
		if (CurrentPlayer == Side.White) {
			CurrentPlayer = Side.Black;
			PlayerTurnText.text = "Player 2 - Black";
		} else {
			CurrentPlayer = Side.White;
			PlayerTurnText.text = "Player 1 - White";
		}
	}

	void EndGame () {
		Debug.Log ("EndGame");
		WinText.text = PlayerTurnText.text + " WIN";
		GameOverScreen.SetActive (true);
	}
}
