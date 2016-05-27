﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class PrototypeBoard : Board {

	[SerializeField] private int _dimension;
	public int Dimension { 
		get { return _dimension; } 
		set { _dimension = value; }
	}

	private FigureFactory _figureFactory;
	private TileFactory _tileFactory;
	private Tile[,] _tileArray;

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {				
		_figureFactory = GetComponent<FigureFactory> ();
		_tileFactory = GetComponent<TileFactory> ();
		_tileArray = new Tile[Dimension, Dimension];
	}

	/* --------------- Interface --------------- */

	public override Tile GetTile(int rowIndex, int colIndex) {
		return (CheckCoordinate(rowIndex, colIndex)) ? _tileArray [colIndex, rowIndex] : null;
	}

	public override void HighlightPossibleMoves (Figure figure) {
		FigureManager.SelectedFigure = figure;
		Tile startTile = GetTile(figure.RowIndex, figure.ColIndex);
		int[,] moves = figure.FigureMoveModel.GetModel (startTile.GetTileSide () == figure.FigureSide);
		if (figure.FigureMoveModel.IsFixedMoveModel) {
			for (int i = 0; i < moves.GetLength (0); i++) {
				HighlightTile (figure.RowIndex + moves [i, 0], figure.ColIndex + moves [i, 1]);
			}
		} else {
			for (int i = 0; i < moves.GetLength (0); i++) {
				int nextRowIndex = figure.RowIndex + moves [i, 0];
				int nextColIndex = figure.ColIndex + moves [i, 1];
				while (HighlightTile (nextRowIndex, nextColIndex)) {
					nextRowIndex += moves [i, 0];
					nextColIndex += moves [i, 1];
				}
			}
		}
	}

	public override bool HighlightTile (int rowIndex, int colIndex) {
		Tile tile = GetTile(rowIndex, colIndex);
		if (tile != null && tile.Type != TileType.Wall) {			
			Figure figureAtDest = tile.Figure;
			if (figureAtDest != null && figureAtDest.IsEnemy ()) {
				tile.HighlightAttack ();
				tile.PossibleMove = true;
				return false;
			} else if (figureAtDest == null) {
				tile.Highlight ();
				tile.PossibleMove = true;
				return true;
			} else {
				return false;
			}
		} 
		return false;
	}

	/* ------------- Other methods ------------- */

	protected override void InitializeBoard() {
		BuildBoard (Dimension);
	}

	protected override void AddFigure (FigureType figureType, Side figureSide, int rowIndex, int colIndex) {
		GameObject figureObject = _figureFactory.GetFigure (figureType, figureSide) as GameObject;
		figureObject.transform.position = new Vector3 (colIndex, rowIndex, -0.1f);
		FigureManager.RegisterFigure (figureObject, _tileArray[rowIndex, colIndex]);
	}

	protected override bool CheckCoordinate (int rowIndex, int colIndex) {
		return !((rowIndex < 0) | (rowIndex > Dimension - 1) | (colIndex < 0) | (colIndex > Dimension - 1));
	}

	private void BuildBoard(int dimension) {
		for (int rowIndex = 0; rowIndex < dimension; rowIndex++) {
			GameObject container = new GameObject();
			container.name = "Row " + rowIndex;
			container.transform.SetParent (_tileObjectsContainer.transform);
			for (int colIndex = 0; colIndex < dimension; colIndex++) {
				Tile tile;
				if ((rowIndex + colIndex) % 2 == 0) {
					tile = _tileFactory.GetWhiteTile ();
				} else {
					tile = _tileFactory.GetBlackTile ();
				}
				tile.transform.position = new Vector3 (colIndex, rowIndex, 0.1f);
				tile.transform.SetParent (container.transform);
				tile.name = "Tile " + colIndex;
				_tileArray [rowIndex, colIndex] = tile;
			}
		}
		// Walls
		int[,] wallsCoordinates = {{5,0},{4,1},{4,2},{5,3},{5,4},{4,5},{4,6},{5,7},{5,8},{4,9}};
		for (int i = 0; i < wallsCoordinates.GetLength(0); i++) {
			int colIndex = wallsCoordinates [i, 0];
			int rowIndex = wallsCoordinates [i, 1];
			_tileFactory.SetTileType(GetTile(rowIndex, colIndex), TileType.Wall);
		}
		// Black Figures
		AddFigure (FigureType.Pawn, Side.Black, 1, 4);
		AddFigure (FigureType.Pawn, Side.Black, 1, 5);
		AddFigure (FigureType.Knight, Side.Black, 0, 3);
		AddFigure (FigureType.King, Side.Black, 0, 4);
		AddFigure (FigureType.Queen, Side.Black, 0, 5);
		AddFigure (FigureType.Knight, Side.Black, 0, 6);
		AddFigure (FigureType.Bishop, Side.Black, 0, 7);
		AddFigure (FigureType.Rook, Side.Black, 0, 8);

		// White Figures
		AddFigure (FigureType.Pawn, Side.White, 8, 4);
		AddFigure (FigureType.Pawn, Side.White, 8, 5);
		AddFigure (FigureType.Knight, Side.White, 9, 6);
		AddFigure (FigureType.King, Side.White, 9, 5);
		AddFigure (FigureType.Queen, Side.White, 9, 4);
		AddFigure (FigureType.Knight, Side.White, 9, 3);
		AddFigure (FigureType.Bishop, Side.White, 9, 2);
		AddFigure (FigureType.Rook, Side.White, 9, 1);
		Messenger.Broadcast ("NextTurn");
	}
}
