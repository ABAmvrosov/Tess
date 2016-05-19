using UnityEngine;
using System.Collections;

public abstract class Figure : MonoBehaviour {
	public Side side;
	protected int rowIndex;
	protected int colIndex;

	void Start() {
		UpdatePosition ();
		EventManager.OnFigureMove += UpdatePosition;
	}

	void OnMouseDown() {
		if (!GameManager.gm.IsFigureTaken()) {
			GameManager.gm.PickUpFigure ();
			GameManager.gm.moveFromCell = GameManager.gm.board.GetCell (rowIndex, colIndex);
			PossibleMoves ();
		}
	}

	void UpdatePosition () {
		rowIndex = (int)this.transform.position.x;
		colIndex = (int)this.transform.position.y;
	}

	protected bool HighlightCell(int rowIndex, int colIndex) {
		Cell cell = GameManager.gm.board.GetCell (rowIndex, colIndex);
		if (cell != null && cell.GetTileType () != TileType.Wall && cell.figure == null) {
			cell.Highlight ();
			cell.possibleMove = true;
			return true;
		} else
			return false;
	}

	protected bool IsFriendlyTile () {
		return side == GameManager.gm.board.GetCell (rowIndex, colIndex).GetCellSide ();
	}

	protected abstract void PossibleMoves ();
}
