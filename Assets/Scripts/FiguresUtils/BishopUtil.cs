using UnityEngine;
using System.Collections;

public class BishopUtil : MonoBehaviour {

	static bool canMoveNext = true;
	
	public static void PossibleMoves (Figure figure) {
		
		// Up-Right direction
		for (int i = 1; ; i++) {
			if (canMoveNext) {
				CheckCell (figure.transform.position.x + i, figure.transform.position.y + i, figure.side, ref canMoveNext);
			} else break;
		}
		canMoveNext = true;
		
		// Up-Left direction
		for (int i = 1; ; i++) {
			if (canMoveNext) {
				CheckCell (figure.transform.position.x + i, figure.transform.position.y - i, figure.side, ref canMoveNext);
			} else break;
		}
		canMoveNext = true;
		
		// Down-Left direction
		for (int i = 1; ; i++) {
			if (canMoveNext) {
				CheckCell (figure.transform.position.x - i, figure.transform.position.y + i, figure.side, ref canMoveNext);
			} else break;
		}
		canMoveNext = true;
		
		// Down-Right direction
		for (int i = 1; ; i++) {
			if (canMoveNext) {
				CheckCell (figure.transform.position.x - i, figure.transform.position.y - i, figure.side, ref canMoveNext);
			} else break;
		}
		canMoveNext = true;
	}
	
	public static void UnHighlightPossibleMoves (Figure figure) {
		
		// Up direction
		for (int i = 1; ; i++) {
			if (canMoveNext) {
				UnHighlightCell (figure.transform.position.x + i, figure.transform.position.y + i, figure.side, ref canMoveNext);
			} else break;
		}
		canMoveNext = true;
		
		// Down direction
		for (int i = 1; ; i++) {
			if (canMoveNext) {
				UnHighlightCell (figure.transform.position.x + i, figure.transform.position.y - i, figure.side, ref canMoveNext);
			} else break;
		}
		canMoveNext = true;
		
		// Left direction
		for (int i = 1; ; i++) {
			if (canMoveNext) {
				UnHighlightCell (figure.transform.position.x - i, figure.transform.position.y + i, figure.side, ref canMoveNext);
			} else break;
		}
		canMoveNext = true;

		// Right direction
		for (int i = 1; ; i++) {
			if (canMoveNext) {
				UnHighlightCell (figure.transform.position.x - i, figure.transform.position.y - i, figure.side, ref canMoveNext);
			} else break;
		}
		canMoveNext = true;
	}
	
	public static void Attack (Figure figure) {
		figure.parentCell.figure = null;
		figure.gameObject.SetActive (false);
	}
	
	
	static void CheckCell (float x, float y, SideType sideType, ref bool canMoveNext) {
		if (!BoardManager.isCoordinateOk (x, y)) {
			canMoveNext = false;
			return;
		}
		Cell cell = GameManager.gm.board.GetCell (x, y);
		
		if (cell.tileType != TileTypes.Wall && !cell.figure) {
			cell.GetComponent<SpriteRenderer> ().color = Color.green;
			cell.moveHighLightOn = true;
		} else if (cell.figure && cell.figure.side != sideType) {
			cell.GetComponent<SpriteRenderer> ().color = Color.red;
			cell.moveHighLightOn = true;
			canMoveNext = false;
		} else {
			canMoveNext = false;
		}
		
	}
	
	static void UnHighlightCell (float x, float y, SideType sideType, ref bool canMoveNext) {
		if (!BoardManager.isCoordinateOk (x, y)) {
			canMoveNext = false;
			return;
		}
		Cell cell = GameManager.gm.board.GetCell (x, y);
		
		if (cell.tileType != TileTypes.Wall && !cell.figure) {
			cell.GetComponent<SpriteRenderer> ().color = Color.white;
			cell.moveHighLightOn = false;
		} else if (cell.figure && cell.figure.side != sideType) {
			cell.GetComponent<SpriteRenderer> ().color = Color.white;
			cell.moveHighLightOn = false;
			canMoveNext = false;
		} else {
			canMoveNext = false;
		}
	}
}
