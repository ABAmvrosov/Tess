using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public static GameManager gm;
	public Board board;
	public Text playerTurn;
	public FigureManager figureManager;
	public Side currentPlayer { get; private set;}

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
		if (gm == null)
			gm = this.GetComponent<GameManager> ();
		if (figureManager == null)
			figureManager = this.GetComponent<FigureManager> ();
		currentPlayer = Side.White;
		EventManager.OnFigureMove += EndTurn;
	}


	/* --------------- Interface --------------- */

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
}
