using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class FigureManager : MonoBehaviour {
	
	[HideInInspector]
	public Figure SelectedFigure;

	private List<GameObject> whiteFigures = new List<GameObject>();
	private List<GameObject> blackFigures = new List<GameObject>();

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
		EventManager.GameStarted += ChangeActiveSide;
	}

	void Start () {
		EventManager.OnFigureMove += ChangeActiveSide;
	}

	/* --------------- Interface --------------- */

	public void RegisterFigure (GameObject figureObject, Side figureSide, Tile tile) {
		tile.Figure = figureObject.GetComponent<Figure> ();
		if (figureSide == Side.Black)
			blackFigures.Add (figureObject);
		else
			whiteFigures.Add (figureObject);
	}

	public void Move (Tile destination) {
		if (destination.Figure != null && destination.Figure.IsEnemy ()) {
			Debug.Log ("Attack");
			DestroyFigure (destination.Figure);
			MoveFigure (destination);

		} else {
			Debug.Log ("Move");
			MoveFigure (destination);
		} 
	}

	/* ------------- Other methods ------------- */

	private void MoveFigure(Tile destination) {
		Tile startTile = GameManager.GM.GameBoard.GetTile (SelectedFigure.RowIndex, SelectedFigure.ColIndex);
		startTile.Figure = null;
		destination.Figure = SelectedFigure;
		SelectedFigure.transform.position = new Vector3 (destination.transform.position.x, destination.transform.position.y, 0f);
		EventManager.OnFigureMove ();
	}

	private void ChangeActiveSide () {
		if (GameManager.GM.CurrentPlayer == Side.White) {
			whiteFigures.ForEach (ActivateCollider);
			blackFigures.ForEach (DeactivateCollider);
		} else if (GameManager.GM.CurrentPlayer == Side.Black) {
			whiteFigures.ForEach (DeactivateCollider);
			blackFigures.ForEach (ActivateCollider);
		}
	}

	private void ActivateCollider (GameObject figureObject) {
		figureObject.GetComponent<BoxCollider2D> ().enabled = true;
	}

	private void DeactivateCollider (GameObject figureObject) {
		figureObject.GetComponent<BoxCollider2D> ().enabled = false;
	}

	private void DestroyFigure (Figure figure) {
		if (figure.FigureSide == Side.Black) {
			blackFigures.Remove (figure.gameObject);
			Destroy (figure.gameObject);
		} else {
			whiteFigures.Remove (figure.gameObject);
			Destroy (figure.gameObject);
		}
	}
}
