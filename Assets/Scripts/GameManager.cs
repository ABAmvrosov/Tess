using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
//	public EventManager events;
	public BoardManager board;
	public Figure figureForMoveHandler;
	public bool figureTaken;

	void Awake () {
		if (gm == null)
			gm = this.GetComponent<GameManager> ();
		if (board == null)
			board = GameObject.FindGameObjectWithTag ("Board").GetComponent<BoardManager> ();
//		if (events == null)
//			events = GameObject.FindGameObjectWithTag ("EventManager").GetComponent<EventManager> ();
	}

	public void TakeFigure (Figure figure) {
		figureForMoveHandler = figure;
		figureTaken = true;
	}

	public void DropFigure () {
		figureForMoveHandler = null;
		figureTaken = false;
	}
}
