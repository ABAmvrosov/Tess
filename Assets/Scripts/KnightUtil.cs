using UnityEngine;
using System.Collections;

public static class KnightUtil {

	public static void UnHighlightPossibleMoves (float x, float y) {
		UnHighlightCell (x + 1f, y + 2f);
		UnHighlightCell (x + 2f, y + 1f);
		UnHighlightCell (x + 2f, y - 1f);
		UnHighlightCell (x + 1f, y - 2f);
		UnHighlightCell (x - 1f, y - 2f);
		UnHighlightCell (x - 2f, y - 1f);
		UnHighlightCell (x - 2f, y + 1f);
		UnHighlightCell (x - 1f, y + 2f);

	}

	
	public static void PossibleMoves (Figure figure) {
		CheckCell (figure.transform.position.x + 1f, figure.transform.position.y + 2f, figure.side);
		CheckCell (figure.transform.position.x + 2f, figure.transform.position.y + 1f, figure.side);
		CheckCell (figure.transform.position.x + 2f, figure.transform.position.y - 1f, figure.side);
		CheckCell (figure.transform.position.x + 1f, figure.transform.position.y - 2f, figure.side);
		CheckCell (figure.transform.position.x - 1f, figure.transform.position.y - 2f, figure.side);
		CheckCell (figure.transform.position.x - 2f, figure.transform.position.y - 1f, figure.side);
		CheckCell (figure.transform.position.x - 2f, figure.transform.position.y + 1f, figure.side);
		CheckCell (figure.transform.position.x - 1f, figure.transform.position.y + 2f, figure.side);

	}

	public static void Attack (Figure figure) {
		figure.parentCell.figure = null;
		figure.gameObject.SetActive (false);
	}

	static void CheckCell (float x, float y, SideType sideType) {
		if (!BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		if (cell.tileType != TileTypes.Wall && !cell.figure) {
			cell.GetComponent<SpriteRenderer> ().color = Color.green;
			cell.moveHighLightOn = true;
		} else if (cell.figure && cell.figure.side != sideType) {
			cell.GetComponent<SpriteRenderer> ().color = Color.red;
			cell.moveHighLightOn = true;
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
