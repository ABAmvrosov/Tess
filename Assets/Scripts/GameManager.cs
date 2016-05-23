using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour {
	
	[HideInInspector]
	public static GameManager GM;

	public Text PlayerTurnText;
	public GameObject GameOverScreen;
	public Text WinText;

	public Board GameBoard { get; private set;}
	public FigureManager FigureManager { get; private set;}
	public Side CurrentPlayer { get; private set;}

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
		if (GM == null)
			GM = this.GetComponent<GameManager> ();
		if (FigureManager == null)
			FigureManager = this.GetComponent<FigureManager> ();
		if (GameBoard == null)
			GameBoard = GameObject.FindGameObjectWithTag ("Board").GetComponent<Board> ();
		if (PlayerTurnText == null)
			Debug.LogError ("Player turn text not specified");
		if (GameOverScreen == null)
			Debug.LogError ("GameOverScreen object not specified");
		if (WinText == null)
			Debug.LogError ("Win text not specified");
		CurrentPlayer = Side.White;
		EventManager.OnFigureMove += EndTurn;
		EventManager.KingDead += EndGame;
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
		WinText.text = PlayerTurnText.text + " WIN";
		GameOverScreen.SetActive (true);
	}
}
