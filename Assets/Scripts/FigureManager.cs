using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FigureManager : MonoBehaviour {
	public Figure selectedFigure;

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

	public void RegisterFigure (GameObject figure, Side side, Tile tile) {
		figuresOnBoard.Add (figure.GetComponent<Figure> (), tile);
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

	public bool isTileEmpty (Tile tile) {
		return figuresOnBoard.ContainsValue (tile);
	}

	public void MoveFigure (Tile destination) {
		Tile startTile = null;
		figuresOnBoard.TryGetValue (selectedFigure, out startTile);
		figuresOnBoard.Remove (selectedFigure);
		figuresOnBoard.Add (selectedFigure, destination);
		selectedFigure.transform.SetParent (destination.transform);
		selectedFigure.transform.position = new Vector3 (destination.transform.position.x, destination.transform.position.y, 0f);
		EventManager.OnFigureMove ();
	}

	/* ------------- Other methods ------------- */

	private void ActivateCollider (GameObject figure) {
		figure.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void DeactivateCollider (GameObject figure) {
		figure.GetComponent<BoxCollider2D> ().enabled = false;
	}
}
