using UnityEngine;
using System.Collections.Generic;

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

	public void ActivateFigures () {
        MovementCard moveCard = (MovementCard)GameManager.TheCardManager.ActiveCard;
		List<FigureType> ableTypes = moveCard.AbleTypes;
		foreach (Figure figure in figuresOnBoard) {
            bool playerCanMoveIt = figure.FigureSide == GameManager.GM.CurrentPlayer;
            if (ableTypes.Contains (figure.Type) && playerCanMoveIt) {
				figure.CanMove = true;
			}
		}
	}

	private void MoveFigure(Tile destination) {
		Tile startTile = GameManager.TheBoardController.GetTile (SelectedFigure.Coordinates);
		startTile.Figure = null;
		destination.Figure = SelectedFigure;
		SelectedFigure.transform.position = new Vector3 (destination.transform.position.x, destination.transform.position.y, 0f);
		Messenger.Broadcast ("FigureMoved");
	}

	private void DestroyFigure (Figure figure) {
		figure.gameObject.SetActive (false);
		figuresOnBoard.Remove (figure);
	}
}
