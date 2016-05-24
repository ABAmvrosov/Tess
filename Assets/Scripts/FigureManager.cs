using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class FigureManager : MonoBehaviour {
	
	[HideInInspector]
	public Figure SelectedFigure;

	private List<GameObject> _whiteFigures = new List<GameObject>();
	private List<GameObject> _blackFigures = new List<GameObject>();

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
//		EventManager.GameStarted += ChangeActiveSide;
	}

	void Start () {
//		EventManager.OnFigureMove += ChangeActiveSide;
	}

	/* --------------- Interface --------------- */

	public void RegisterFigure (GameObject figureObject, Side figureSide, Tile tile) {
		tile.Figure = figureObject.GetComponent<Figure> ();
		if (figureSide == Side.Black)
			_blackFigures.Add (figureObject);
		else
			_whiteFigures.Add (figureObject);
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

//	private void ChangeActiveSide () {
//		if (GameManager.GM.CurrentPlayer == Side.White) {
//			_whiteFigures.ForEach (ActivateCollider);
//			_blackFigures.ForEach (DeactivateCollider);
//		} else if (GameManager.GM.CurrentPlayer == Side.Black) {
//			_whiteFigures.ForEach (DeactivateCollider);
//			_blackFigures.ForEach (ActivateCollider);
//		}
//	}

//	private void ActivateCollider (GameObject figureObject) {
//		figureObject.GetComponent<BoxCollider2D> ().enabled = true;
//	}
//
//	private void DeactivateCollider (GameObject figureObject) {
//		figureObject.GetComponent<BoxCollider2D> ().enabled = false;
//	}

	private void DestroyFigure (Figure figure) {
		if (figure.FigureSide == Side.Black) {
			_blackFigures.Remove (figure.gameObject);
			Destroy (figure.gameObject);
		} else {
			_whiteFigures.Remove (figure.gameObject);
			Destroy (figure.gameObject);
		}
	}
}
