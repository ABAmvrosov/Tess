using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
//	public EventManager events;
	public BoardManager board;
	public Figure figureForMoveHandler;
	public GroundCard groundCard;
	public bool figureTaken;
	public Text UITurn;
	public Sprite white;
	public Sprite black;
	public Sprite wall;

	string _playerOneTurn = "Player 1 turn";
	string _playerTwoTurn = "Player 2 turn";

	void Awake () {
		if (gm == null)
			gm = this.GetComponent<GameManager> ();
		if (board == null)
			board = GameObject.FindGameObjectWithTag ("Board").GetComponent<BoardManager> ();
		//		if (events == null)
		//			events = GameObject.FindGameObjectWithTag ("EventManager").GetComponent<EventManager> ();

		UITurn.text = "Player 1 turn";
		EventManager.OnCardDone += TurnSwitch;
	}

	public void TakeFigure (Figure figure) {
		figureForMoveHandler = figure;
		figureTaken = true;
	}

	public void DropFigure () {
		figureForMoveHandler = null;
		figureTaken = false;
	}

	public void Reset () {
		Application.LoadLevel ("sandbox");
	}

	void TurnSwitch () {
		switch (UITurn.text) {
		case "Player 1 turn":
			UITurn.text = _playerTwoTurn;
			break;
		case "Player 2 turn":
			UITurn.text = _playerOneTurn;
			break;
		}
	}
}
