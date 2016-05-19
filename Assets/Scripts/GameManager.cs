using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Board board;
	public Text playerTurn;
	[HideInInspector]
	public static GameManager gm;
	[HideInInspector]
	public GameResources resourses;
	[HideInInspector]
	public Cell moveFromCell;

	private enum PlayerTurn {Player1, Player2}
	private PlayerTurn currentPlayer;
	private bool isFigureTaken;

	void Awake () {
		if (gm == null)
			gm = this.GetComponent<GameManager> ();
		if (resourses == null)
			resourses = this.GetComponent<GameResources> ();
		currentPlayer = PlayerTurn.Player1;
		EventManager.OnFigureMove += DropFigure;
		EventManager.OnFigureMove += EndTurn;
	}

	public bool IsFigureTaken() {
		return isFigureTaken;
	}

	public void PickUpFigure() {
		isFigureTaken = true;
	}

	public void DropFigure() {
		moveFromCell = null;
		isFigureTaken = false;
	}

	void EndTurn () {
		if (currentPlayer == PlayerTurn.Player1) {
			currentPlayer = PlayerTurn.Player2;
			playerTurn.text = "Player 2";
		} else {
			currentPlayer = PlayerTurn.Player1;
			playerTurn.text = "Player 1";
		}
	}
}
