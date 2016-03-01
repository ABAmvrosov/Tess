﻿using UnityEngine;
using System.Collections;

public static class PasteUtil {

	enum ActionType {Highlight, UnHighlight, Invert}

	public static void Highlight (Cell cell, GroundCardFigure groundCardFigure) {
		switch (groundCardFigure) {
		case GroundCardFigure.Cube:
			Cube (cell.transform.position.x, cell.transform.position.y, ActionType.Highlight);
			break;
		case GroundCardFigure.J:
			J (cell.transform.position.x, cell.transform.position.y, ActionType.Highlight);
			break;
		case GroundCardFigure.L:
			L (cell.transform.position.x, cell.transform.position.y, ActionType.Highlight);
			break;
		case GroundCardFigure.S:
			S (cell.transform.position.x, cell.transform.position.y, ActionType.Highlight);
			break;
		case GroundCardFigure.T:
			T (cell.transform.position.x, cell.transform.position.y, ActionType.Highlight);
			break;
		case GroundCardFigure.Z:
			Z (cell.transform.position.x, cell.transform.position.y, ActionType.Highlight);
			break;
		}
	}

	public static void UnHighlight(Cell cell, GroundCardFigure groundCardFigure) {
		switch (groundCardFigure) {
		case GroundCardFigure.Cube:
			Cube (cell.transform.position.x, cell.transform.position.y, ActionType.UnHighlight);
			break;
		case GroundCardFigure.J:
			J (cell.transform.position.x, cell.transform.position.y, ActionType.UnHighlight);
			break;
		case GroundCardFigure.L:
			L (cell.transform.position.x, cell.transform.position.y, ActionType.UnHighlight);
			break;
		case GroundCardFigure.S:
			S (cell.transform.position.x, cell.transform.position.y, ActionType.UnHighlight);
			break;
		case GroundCardFigure.T:
			T (cell.transform.position.x, cell.transform.position.y, ActionType.UnHighlight);
			break;
		case GroundCardFigure.Z:
			Z (cell.transform.position.x, cell.transform.position.y, ActionType.UnHighlight);
			break;
		}	
	}

	public static void Paste (Cell cell, GroundCardFigure groundCardFigure) {
		switch (groundCardFigure) {
		case GroundCardFigure.Cube:
			Cube (cell.transform.position.x, cell.transform.position.y, ActionType.Invert);
			break;
		case GroundCardFigure.J:
			J (cell.transform.position.x, cell.transform.position.y, ActionType.Invert);
			break;
		case GroundCardFigure.L:
			L (cell.transform.position.x, cell.transform.position.y, ActionType.Invert);
			break;
		case GroundCardFigure.S:
			S (cell.transform.position.x, cell.transform.position.y, ActionType.Invert);
			break;
		case GroundCardFigure.T:
			T (cell.transform.position.x, cell.transform.position.y, ActionType.Invert);
			break;
		case GroundCardFigure.Z:
			Z (cell.transform.position.x, cell.transform.position.y, ActionType.Invert);
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
			Paste (x, y);
			Paste (x + 1f, y);
			Paste (x + 1f, y - 1f);
			Paste (x, y - 1f);
			break;
		}
	}

	static void J (float x, float y, ActionType actionType) {
		switch (actionType) {
		case ActionType.Highlight:
			HighlightCell (x, y);
			HighlightCell (x, y - 1f);
			HighlightCell (x, y - 2f);
			HighlightCell (x - 1f, y - 2f);
			break;
		case ActionType.UnHighlight:
			UnHighlightCell (x, y);
			UnHighlightCell (x, y - 1f);
			UnHighlightCell (x, y - 2f);
			UnHighlightCell (x - 1f, y - 2f);
			break;
		case ActionType.Invert:
			Debug.Log("Invert J Calling");
			Paste (x, y);
			Paste (x, y - 1f);
			Paste (x, y - 2f);
			Paste (x - 1f, y - 2f);
			break;
		}
	}

	static void L (float x, float y, ActionType actionType) {
		switch (actionType) {
		case ActionType.Highlight:
			HighlightCell (x, y);
			HighlightCell (x, y - 1f);
			HighlightCell (x, y - 2f);
			HighlightCell (x + 1f, y - 2f);
			break;
		case ActionType.UnHighlight:
			UnHighlightCell (x, y);
			UnHighlightCell (x, y - 1f);
			UnHighlightCell (x, y - 2f);
			UnHighlightCell (x + 1f, y - 2f);
			break;
		case ActionType.Invert:
			Debug.Log("Invert L Calling");
			Paste (x, y);
			Paste (x, y - 1f);
			Paste (x, y - 2f);
			Paste (x + 1f, y - 2f);
			break;
		}
	}

	static void S (float x, float y, ActionType actionType) {
		switch (actionType) {
		case ActionType.Highlight:
			HighlightCell (x, y);
			HighlightCell (x - 1f, y);
			HighlightCell (x - 1f, y - 1f);
			HighlightCell (x - 2f, y - 1f);
			break;
		case ActionType.UnHighlight:
			UnHighlightCell (x, y);
			UnHighlightCell (x - 1f, y);
			UnHighlightCell (x - 1f, y - 1f);
			UnHighlightCell (x - 2f, y - 1f);
			break;
		case ActionType.Invert:
			Debug.Log("Invert S Calling");
			Paste (x, y);
			Paste (x - 1f, y);
			Paste (x - 1f, y - 1f);
			Paste (x - 2f, y - 1f);
			break;
		}
	}

	static void T (float x, float y, ActionType actionType) {
		switch (actionType) {
		case ActionType.Highlight:
			HighlightCell (x, y);
			HighlightCell (x + 1f, y);
			HighlightCell (x - 1f, y);
			HighlightCell (x - 1f, y - 1f);
			break;
		case ActionType.UnHighlight:
			UnHighlightCell (x, y);
			UnHighlightCell (x + 1f, y);
			UnHighlightCell (x - 1f, y);
			UnHighlightCell (x - 1f, y - 1f);
			break;
		case ActionType.Invert:
			Debug.Log("Invert T Calling");
			Paste (x, y);
			Paste (x + 1f, y);
			Paste (x - 1f, y);
			Paste (x - 1f, y - 1f);
			break;
		}
	}

	static void Z (float x, float y, ActionType actionType) {
		switch (actionType) {
		case ActionType.Highlight:
			HighlightCell (x, y);
			HighlightCell (x + 1f, y);
			HighlightCell (x + 1f, y - 1f);
			HighlightCell (x + 2f, y - 1f);
			break;
		case ActionType.UnHighlight:
			UnHighlightCell (x, y);
			UnHighlightCell (x + 1f, y);
			UnHighlightCell (x + 1f, y - 1f);
			UnHighlightCell (x + 2f, y - 1f);
			break;
		case ActionType.Invert:
			Debug.Log("Invert Z Calling");
			Paste (x, y);
			Paste (x + 1f, y);
			Paste (x + 1f, y - 1f);
			Paste (x + 2f, y - 1f);
			break;
		}
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

	static void Paste (float x, float y) {		
		if (!BoardManager.isCoordinateOk (x, y)) return;
		Cell cell = GameManager.gm.board.GetCell (x, y);
		if (GameManager.gm.activeSide == SideType.DarkSide) {
			cell.tileType = TileTypes.Black;
			cell.GetComponent<SpriteRenderer>().sprite = GameManager.gm.black;
		} else if (GameManager.gm.activeSide == SideType.LightSide) { 
			cell.tileType = TileTypes.White;
			cell.GetComponent<SpriteRenderer>().sprite = GameManager.gm.white;
		}
	}
}