using UnityEngine;
using System.Collections;

public static class PawnUtil {

	public static void UnHighlightPossibleMoves (float x, float y) {
		Debug.Log ("UnHighlight Pawn Called");
		UnHighlightCell (x + 1f, y);
		UnHighlightCell (x - 1f, y);
		UnHighlightCell (x, y + 1f);
		UnHighlightCell (x, y - 1f);
	}

	
	public static void PossibleMoves (float x, float y) {
		HighlightCell (x + 1f, y);
		HighlightCell (x - 1f, y);
		HighlightCell (x, y + 1f);
		HighlightCell (x, y - 1f);
	}
	
	static void HighlightCell (float x, float y) {
		Cell cell = GameManager.gm.board.GetCell (x, y);
		if (cell.tileType != TileTypes.Wall) {
			cell.GetComponent<SpriteRenderer> ().color = Color.green;
			cell.moveHighlightOn = true;
		}
	}

	static void UnHighlightCell (float x, float y) {
		if (BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		if (cell.moveHighlightOn) {
			cell.GetComponent<SpriteRenderer> ().color = Color.white;
			cell.moveHighlightOn = false;
		}
	}
}
