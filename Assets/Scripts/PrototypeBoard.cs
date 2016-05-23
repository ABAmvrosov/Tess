using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class PrototypeBoard : Board {

	public int dimension;

	private FigureFactory figureFactory;
	private TileFactory tileFactory;
	private Tile[,] _tileArray;

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
		figureFactory = GetComponent<FigureFactory> ();
		tileFactory = GetComponent<TileFactory> ();
	}

	/* --------------- Interface --------------- */

	public override Tile GetTile(int rowIndex, int colIndex) {
		return (isCoordinateOk(rowIndex, colIndex)) ? _tileArray [colIndex, rowIndex] : null;
	}

	public override void HighlightPossibleMoves (Figure figure) {
		GameManager.gm.figureManager.selectedFigure = figure;
		Tile startTile = _tileArray[figure.ColIndex, figure.RowIndex];
		figure.moveModel.HighlightMoves (figure, startTile);
	}

	public override bool HighlightTile (int rowIndex, int colIndex) {
		if (isCoordinateOk (rowIndex, colIndex)) {
			Tile tile = _tileArray [colIndex, rowIndex];
			Figure figureAtDest = GameManager.gm.figureManager.FigureOnTile (tile);
			if (figureAtDest != null && figureAtDest.isEnemy ()) {
				tile.HighlightAttack ();
				tile.possibleMove = true;
				return true;
			} else if (tile.type != TileType.Wall && GameManager.gm.figureManager.FigureOnTile (tile) == null) {
				tile.Highlight ();
				tile.possibleMove = true;
				return true;
			} else {
				return false;
			}
		} return false;
	}

	/* ------------- Other methods ------------- */

	protected override void InitializeBoard() {
		BuildBoard (dimension);
		GameManager.gm.figureManager.ChangeActiveSide ();
	}

	private void BuildBoard(int dimension) {
		_tileArray = new Tile[dimension, dimension];
		for (int rowIndex = 0; rowIndex < dimension; rowIndex++) {
			GameObject container = new GameObject();
			container.name = "Row " + rowIndex;
			container.transform.SetParent (tileObjectsContainer.transform);
			for (int colIndex = 0; colIndex < dimension; colIndex++) {
				Tile tile;
				if ((rowIndex + colIndex) % 2 == 0) {
					tile = tileFactory.GetWhiteTile ();
				} else {
					tile = tileFactory.GetBlackTile ();
				}
				tile.transform.position = new Vector3 (colIndex, rowIndex, 0.1f);
				tile.transform.SetParent (container.transform);
				_tileArray [rowIndex, colIndex] = tile;
			}
		}
		// Walls
		int[,] wallsCoordinates = {{5,0},{4,1},{4,2},{5,3},{5,4},{4,5},{4,6},{5,7},{5,8},{4,9}};
		for (int i = 0; i < wallsCoordinates.GetLength(0); i++) {
			tileFactory.SetTileType(_tileArray[wallsCoordinates[i, 0], wallsCoordinates[i, 1]], TileType.Wall);
		}

		AddFigure (FigureType.Pawn, Side.Black, 1, 4);
		AddFigure (FigureType.Pawn, Side.Black, 1, 5);
		AddFigure (FigureType.Knight, Side.Black, 0, 3);
		AddFigure (FigureType.King, Side.Black, 0, 4);
		AddFigure (FigureType.Queen, Side.Black, 0, 5);
		AddFigure (FigureType.Knight, Side.Black, 0, 6);
		AddFigure (FigureType.Bishop, Side.Black, 0, 7);
		AddFigure (FigureType.Rook, Side.Black, 0, 8);

		AddFigure (FigureType.Pawn, Side.White, 8, 4);
		AddFigure (FigureType.Pawn, Side.White, 8, 5);
		AddFigure (FigureType.Knight, Side.White, 9, 6);
		AddFigure (FigureType.King, Side.White, 9, 5);
		AddFigure (FigureType.Queen, Side.White, 9, 4);
		AddFigure (FigureType.Knight, Side.White, 9, 3);
		AddFigure (FigureType.Bishop, Side.White, 9, 2);
		AddFigure (FigureType.Rook, Side.White, 9, 1);
	}

	protected override void AddFigure (FigureType figureType, Side side, int rowIndex, int colIndex) {
		GameObject figure = figureFactory.GetFigure (figureType, side) as GameObject;
		figure.transform.position = new Vector3 (colIndex, rowIndex, -0.1f);
		GameManager.gm.figureManager.RegisterFigure (figure, side, _tileArray[rowIndex, colIndex]);
	}

	protected override bool isCoordinateOk (int rowIndex, int colIndex) {
		return !((rowIndex < 0) | (rowIndex > dimension - 1) | (colIndex < 0) | (colIndex > dimension - 1));
	}
}
