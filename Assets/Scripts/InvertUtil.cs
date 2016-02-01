using UnityEngine;
using System.Collections;

public static class InvertUtil {

	enum ActionType {Highlight, UnHighlight, Invert}

	public static void Highlight (Cell cell, GroundCardFigure groundCardFigure) {
		switch (groundCardFigure) {
		case GroundCardFigure.Cube:
			Cube (cell.transform.position.x, cell.transform.position.y, ActionType.Highlight);
			break;
		case GroundCardFigure.J:
			J ();
			break;
		case GroundCardFigure.L:
			L ();
			break;
		case GroundCardFigure.S:
			S ();
			break;
		case GroundCardFigure.T:
			T ();
			break;
		case GroundCardFigure.Z:
			Z ();
			break;
		}
	}

	public static void UnHighlight(Cell cell, GroundCardFigure groundCardFigure) {
		switch (groundCardFigure) {
			case GroundCardFigure.Cube:
			Cube (cell.transform.position.x, cell.transform.position.y, ActionType.UnHighlight);
			break;
			case GroundCardFigure.J:
			J ();
			break;
			case GroundCardFigure.L:
			L ();
			break;
			case GroundCardFigure.S:
			S ();
			break;
			case GroundCardFigure.T:
			T ();
			break;
			case GroundCardFigure.Z:
			Z ();
			break;
		}	
	}

	public static void Invert (Cell cell, GroundCardFigure groundCardFigure) {
		switch (groundCardFigure) {
		case GroundCardFigure.Cube:
			Cube (cell.transform.position.x, cell.transform.position.y, ActionType.Invert);
			break;
		case GroundCardFigure.J:
			J ();
			break;
		case GroundCardFigure.L:
			L ();
			break;
		case GroundCardFigure.S:
			S ();
			break;
		case GroundCardFigure.T:
			T ();
			break;
		case GroundCardFigure.Z:
			Z ();
			break;
		}	
	}

	static void Cube (float x, float y, ActionType actionType) {
		switch (actionType) {
		case ActionType.Highlight:
			HighlightCell (x, y);
			HighlightCell (x + 1f, y);
			HighlightCell (x + 1f, y - 1f);
			HighlightCell (x, y - 1f);
			break;
		case ActionType.UnHighlight:
			UnHighlightCell (x, y);
			UnHighlightCell (x + 1f, y);
			UnHighlightCell (x + 1f, y - 1f);
			UnHighlightCell (x, y - 1f);
			break;
		case ActionType.Invert:
			Debug.Log("Invert Cube Calling");
			Invert (x, y);
			Invert (x + 1f, y);
			Invert (x + 1f, y - 1f);
			Invert (x, y - 1f);
			break;
		}
	}

	static void J () {

	}
	
	static void L () {
		
	}
	
	static void S () {
		
	}
	
	static void T () {
		
	}
	
	static void Z () {
		
	}

	static void HighlightCell (float x, float y) {
		if (!BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		cell.GetComponent<SpriteRenderer> ().color = Color.green;
	}

	static void UnHighlightCell (float x, float y) {
		if (!BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		cell.GetComponent<SpriteRenderer> ().color = Color.white;
	}

	static void Invert (float x, float y) {		
		if (!BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		if (cell.tileType == TileTypes.Black) { 
			cell.tileType = TileTypes.White;
			cell.GetComponent<SpriteRenderer>().sprite = GameManager.gm.white;
		} 
		if (cell.tileType == TileTypes.White) { 
			cell.tileType = TileTypes.Black;
			cell.GetComponent<SpriteRenderer>().sprite = GameManager.gm.black;
		}
	}
}
