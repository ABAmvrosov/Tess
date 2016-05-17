using UnityEngine;
using System.Collections;

public abstract class FigureR : MonoBehaviour {
	public Side side;

	protected void HighlightCell(int rowIndex, int colIndex) {
		CellR cell = GameManagerR.gm.board.GetCell (rowIndex, colIndex);
		if (cell.GetTileType() != TileType.Wall) {
			cell.Highlight ();
		}
	}
}
