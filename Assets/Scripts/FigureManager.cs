using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class FigureManager : MonoBehaviour {
	
	[HideInInspector] public Figure SelectedFigure;

	/* ---------- MonoBehavior methods ---------- */


	/* --------------- Interface --------------- */

	public void RegisterFigure (GameObject figureObject, Tile tile) {
		tile.Figure = figureObject.GetComponent<Figure> ();
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
		Messenger.Broadcast ("NextTurn");
	}

	private void DestroyFigure (Figure figure) {
		figure.gameObject.SetActive (false);
	}
}
