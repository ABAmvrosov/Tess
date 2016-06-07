using UnityEngine;
using System.Collections;

public class Figure : MonoBehaviour {

	public Side FigureSide { get; set; }
	public MoveModel MovementModel { get; set; }
	public bool CanMove { 
		get { return canMove; } 
		set { canMove = value; }
	}
	private bool canMove = false;
	public int horCoordinateX {
		get;
		private set;
	}
	public int verCoordinateY {
		get;
		private set;
	}

	void OnEnable() {
		Messenger.AddListener ("NextTurn", UpdatePosition);
	}

	void OnMouseDown () {
		if (GameManager.GM.CurrentPlayer == FigureSide) {
			GameManager.ABoardController.HighlightPossibleMoves (this);
		} else if (GameManager.ABoardController.GetTile(horCoordinateX, verCoordinateY).PossibleMove) {
			GameManager.TheFigureManager.Move (GameManager.ABoardController.GetTile(horCoordinateX, verCoordinateY));
		}
	}

	void OnDisable () {
		Messenger.RemoveListener ("NextTurn", UpdatePosition);
		Messenger<GameObject>.Broadcast ("KillFigure", this.gameObject);
	}

	public bool IsEnemy () {
		if (FigureSide != GameManager.GM.CurrentPlayer) {
			return true;
		} else
			return false;
	}

	protected void UpdatePosition () {
		horCoordinateX = (int) this.transform.position.x;
		verCoordinateY = (int) this.transform.position.y;
	}
}
