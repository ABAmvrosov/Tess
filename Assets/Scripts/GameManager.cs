using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour {
	
	public FigureManager figureManager { get; private set;}
	[HideInInspector]
	public static GameManager gm;

	public Board board;
	public Text playerTurn;
	public GameObject gameOverScreen;
	public Text winText;
	public Side currentPlayer { get; private set;}

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
		if (gm == null)
			gm = this.GetComponent<GameManager> ();
		if (figureManager == null)
			figureManager = this.GetComponent<FigureManager> ();
		currentPlayer = Side.White;
		EventManager.OnFigureMove += EndTurn;
		EventManager.KingDead += GameOver;
	}


	/* --------------- Interface --------------- */

	public void PlayAgain() {
		SceneManager.LoadScene ("prototype"); 
	}

	/* ------------- Other methods ------------- */

	void EndTurn () {
		if (currentPlayer == Side.White) {
			currentPlayer = Side.Black;
			playerTurn.text = "Player 2 - Black";
		} else {
			currentPlayer = Side.White;
			playerTurn.text = "Player 1 - White";
		}
	}

	void GameOver () {
		winText.text = playerTurn.text + " WIN";
		gameOverScreen.SetActive (true);
	}
}
