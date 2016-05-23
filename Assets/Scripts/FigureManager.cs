using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class FigureManager : MonoBehaviour {
	
	[HideInInspector]
	public Figure selectedFigure;

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
		tile.figure = figure.GetComponent<Figure> ();
		if (side == Side.Black)
			blackFigures.Add (figure);
		else
			whiteFigures.Add (figure);
	}

	public void MoveFigure (Tile destination) {
		if (destination.figure != null && destination.figure.isEnemy ()) {
			Debug.Log ("Attack");
			Tile startTile = GameManager.gm.board.GetTile (selectedFigure.RowIndex, selectedFigure.ColIndex);
			startTile.figure = null;
			DestroyFigure (destination.figure);
			destination.figure = selectedFigure;
			selectedFigure.transform.position = new Vector3 (destination.transform.position.x, destination.transform.position.y, 0f);
			EventManager.OnFigureMove ();
		} else {
			Debug.Log ("Move");
			Tile startTile = GameManager.gm.board.GetTile (selectedFigure.RowIndex, selectedFigure.ColIndex);
			startTile.figure = null;
			destination.figure = selectedFigure;
			selectedFigure.transform.position = new Vector3 (destination.transform.position.x, destination.transform.position.y, 0f);
			EventManager.OnFigureMove ();
		} 
	}

	/* ------------- Other methods ------------- */

	private void ActivateCollider (GameObject figure) {
		figure.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void DeactivateCollider (GameObject figure) {
		figure.GetComponent<BoxCollider2D> ().enabled = false;
	}

	private void DestroyFigure (Figure figure) {
		if (figure.side == Side.Black) {
			blackFigures.Remove (figure.gameObject);
			Destroy (figure.gameObject);
		} else {
			whiteFigures.Remove (figure.gameObject);
			Destroy (figure.gameObject);
		}
	}
}
