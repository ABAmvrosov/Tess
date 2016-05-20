using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FigureManager : MonoBehaviour {
	public Dictionary<Figure, Tile> figuresOnBoard = new Dictionary<Figure, Tile>();

	private List<GameObject> whiteFigures = new List<GameObject>();
	private List<GameObject> blackFigures = new List<GameObject>();

	/* ---------- MonoBehavior methods ---------- */

	void Start () {
		EventManager.OnFigureMove += ChangeActiveSide;
	}

	/* --------------- Interface --------------- */

	public void ChangeActiveSide () {
		if (GameManager.gm.currentPlayer == Side.White) {
			whiteFigures.ForEach (ActivateCollider);
			blackFigures.ForEach (DeactivateCollider);
		} else if (GameManager.gm.currentPlayer == Side.Black) {
			whiteFigures.ForEach (DeactivateCollider);
			blackFigures.ForEach (ActivateCollider);
		}
	}

	public void AddFigure (GameObject figure, Side side) {
		if (side == Side.Black)
			blackFigures.Add (figure);
		else
			whiteFigures.Add (figure);
	}

	public Tile FigurePosition (Figure figure) {
		Tile tile = null;
		figuresOnBoard.TryGetValue (figure, out tile);
		return tile;
	}
//
//	public void RelocateFigure (Figure figure, Tile destination) {
//		figuresOnBoard.Remove (figure);
//		figuresOnBoard.Add (figure, destination);
//	}

	/* ------------- Other methods ------------- */

	private void ActivateCollider (GameObject figure) {
		figure.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void DeactivateCollider (GameObject figure) {
		figure.GetComponent<BoxCollider2D> ().enabled = false;
	}
}
