using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class FigureManager : MonoBehaviour {
	
	[HideInInspector]
	public Figure selectedFigure;
	[HideInInspector]
	public Dictionary<Tile, Figure> figuresOnBoard = new Dictionary<Tile, Figure>();

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
		figuresOnBoard.Add (tile, figure.GetComponent<Figure> ());
		if (side == Side.Black)
			blackFigures.Add (figure);
		else
			whiteFigures.Add (figure);
	}

	public Figure FigureOnTile (Tile tile) {
		Figure figure = null;
		figuresOnBoard.TryGetValue(tile, out figure);
		return figure;
	}

	public void MoveFigure (Tile destination) {
		Tile startTile = GameManager.gm.board.GetTile(selectedFigure.RowIndex, selectedFigure.ColIndex);
		figuresOnBoard.Remove (startTile);
		figuresOnBoard.Add (destination, selectedFigure);
		selectedFigure.transform.SetParent (destination.transform);
		selectedFigure.transform.position = new Vector3 (destination.transform.position.x, destination.transform.position.y, 0f);
		EventManager.OnFigureMove ();
	}

	public void AttackFigure (Tile destination) {
		
	}

	/* ------------- Other methods ------------- */

	private void ActivateCollider (GameObject figure) {
		figure.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void DeactivateCollider (GameObject figure) {
		figure.GetComponent<BoxCollider2D> ().enabled = false;
	}
}
