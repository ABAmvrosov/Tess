using UnityEngine;
using System.Collections;

public class KingUtil : MonoBehaviour {
		
	public static void PossibleMoves (Figure figure) {
		for (int i = -1; i < 2; i++) {
			for (int j = -1; j < 2; j++) {
				if (i == 0 & j == 0) {
				} else {
					CheckCell(figure.transform.position.x + i, figure.transform.position.y + j, figure.side);
				}
			}
		}
	}

	public static void UnHighlightPossibleMoves (float x, float y) {
		for (int i = -1; i < 2; i++) {
			for (int j = -1; j <2; j++) {
				if (i == 0 && j == 0) {
				} else {
					UnHighlightCell(x + i, y + j);
				}
			}
		}
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
