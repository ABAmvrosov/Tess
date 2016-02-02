using UnityEngine;
using System.Collections;

public static class PawnUtil {

	public static void UnHighlightPossibleMoves (float x, float y) {
//		Debug.Log ("UnHighlight Pawn Called");
		UnHighlightCell (x + 1f, y);
		UnHighlightCell (x - 1f, y);
		UnHighlightCell (x, y + 1f);
		UnHighlightCell (x, y - 1f);
		UnCheckEnemy (x + 1f, y + 1f);
		UnCheckEnemy (x - 1f, y + 1f);
		UnCheckEnemy (x - 1f, y - 1f);
		UnCheckEnemy (x + 1f, y - 1f);

	}

	
	public static void PossibleMoves (Figure figure) {
		HighlightCell (figure.transform.position.x + 1f, figure.transform.position.y);
		HighlightCell (figure.transform.position.x - 1f, figure.transform.position.y);
		HighlightCell (figure.transform.position.x, figure.transform.position.y + 1f);
		HighlightCell (figure.transform.position.x, figure.transform.position.y - 1f);
		CheckEnemy (figure.transform.position.x + 1f, figure.transform.position.y + 1f, figure.side);
		CheckEnemy (figure.transform.position.x - 1f, figure.transform.position.y + 1f, figure.side);
		CheckEnemy (figure.transform.position.x - 1f, figure.transform.position.y - 1f, figure.side);
		CheckEnemy (figure.transform.position.x + 1f, figure.transform.position.y - 1f, figure.side);
	}

	public static void Attack (Figure figure) {
		figure.parentCell.figure = null;
		figure.gameObject.SetActive (false);
	}

	static void HighlightCell (float x, float y) {
		if (!BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		if (cell.tileType != TileTypes.Wall && !cell.figure) {
			cell.GetComponent<SpriteRenderer> ().color = Color.green;
			cell.moveHighLightOn = true;
		}
	}

	static void CheckEnemy (float x, float y, SideType sideType) {
		if (!BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		if (cell.figure && cell.figure.side != sideType) {
			cell.GetComponent<SpriteRenderer> ().color = Color.red;
			cell.moveHighLightOn = true;
		}
	}

	static void UnCheckEnemy (float x, float y) {
		if (!BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		if (cell.moveHighLightOn) {
			cell.GetComponent<SpriteRenderer> ().color = Color.white;
			cell.moveHighLightOn = false;
		}
	}

	static void UnHighlightCell (float x, float y) {
		if (!BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		if (cell.moveHighLightOn) {
			cell.GetComponent<SpriteRenderer> ().color = Color.white;
			cell.moveHighLightOn = false;
		}
	}
}
