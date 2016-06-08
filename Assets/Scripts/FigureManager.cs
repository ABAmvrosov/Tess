using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public sealed class FigureManager : MonoBehaviour {
	
	[HideInInspector] public Figure SelectedFigure;
	private List<Figure> figuresOnBoard = new List<Figure>();

	public void RegisterFigure (Figure figure, Tile tile) {
		tile.Figure = figure;
		figuresOnBoard.Add (figure);
	}

	public void Move (Tile destination) {
		if (destination.Figure != null && destination.Figure.IsEnemy ()) {
			DestroyFigure (destination.Figure);
			MoveFigure (destination);

		} else {
			MoveFigure (destination);
		} 
	}

	public void ActivateFigures (MovementCard moveCard) {
		List<FigureType> ableTypes = moveCard.AbleTypes;
		foreach (Figure figure in figuresOnBoard) {
            bool playerCanMoveIt = figure.FigureSide == GameManager.GM.CurrentPlayer;
            if (ableTypes.Contains (figure.Type) && playerCanMoveIt) {
				figure.CanMove = true;
			}
		}
	}

	private void MoveFigure(Tile destination) {
		Tile startTile = GameManager.TheBoardController.GetTile (SelectedFigure.horCoordinateX, SelectedFigure.verCoordinateY);
		startTile.Figure = null;
		destination.Figure = SelectedFigure;
		SelectedFigure.transform.position = new Vector3 (destination.transform.position.x, destination.transform.position.y, 0f);
        SelectedFigure.CanMove = false;
		Messenger.Broadcast ("NextTurn");
	}

	private void DestroyFigure (Figure figure) {
		figure.gameObject.SetActive (false);
		figuresOnBoard.Remove (figure);
	}
}
