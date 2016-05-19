using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {
	
	public int dimension;
	public Cell cellPrefab;

	private Cell[,] _cellsArray;

	void Start() {
		InitBoardArray (dimension);
	}

	public Cell GetCell(int rowIndex, int colIndex) {
		return (isCoordinateOk(rowIndex, colIndex)) ? _cellsArray [colIndex, rowIndex] : null;
	}

	public static void MoveFigure (Cell startCell, Cell destCell) {
		GameObject movingFigure = startCell.figure;
		startCell.figure = null;
		destCell.figure = movingFigure;
		movingFigure.transform.SetParent (destCell.transform);
		movingFigure.transform.position = new Vector3 (destCell.transform.position.x, destCell.transform.position.y, 0f);
		EventManager.OnFigureMove ();
	}

	//Test board,looks like chessboard. Some figures.
	void InitBoardArray(int dimension) {
		_cellsArray = new Cell[dimension, dimension];
		for (int rowIndex = 0; rowIndex < dimension; rowIndex++) {
			GameObject container = new GameObject();
			container.name = "Row" + rowIndex;
			for (int colIndex = 0; colIndex < dimension; colIndex++) {
				Cell cell = Instantiate (cellPrefab, new Vector3 (colIndex, rowIndex, 0.1f), Quaternion.identity) as Cell;
				cell.transform.SetParent (container.transform);
				if ((rowIndex + colIndex) % 2 == 0) {
					cell.SetTileType(TileType.White);
				} else {
					cell.SetTileType(TileType.Black);
				}
				_cellsArray [rowIndex, colIndex] = cell;
			}
		}
		//hardcode walls
		_cellsArray[5,0].SetTileType(TileType.Wall);
		_cellsArray[4,1].SetTileType(TileType.Wall);
		_cellsArray[4,2].SetTileType(TileType.Wall);
		_cellsArray[5,3].SetTileType(TileType.Wall);
		_cellsArray[5,4].SetTileType(TileType.Wall);
		_cellsArray[4,5].SetTileType(TileType.Wall);
		_cellsArray[4,6].SetTileType(TileType.Wall);
		_cellsArray[5,7].SetTileType(TileType.Wall);
		_cellsArray[5,8].SetTileType(TileType.Wall);
		_cellsArray[4,9].SetTileType(TileType.Wall);

		AddFigure (FigureType.Pawn, Side.Dark, 1, 4);
		AddFigure (FigureType.Pawn, Side.Dark, 1, 5);
		AddFigure (FigureType.Knight, Side.Dark, 0, 3);
		AddFigure (FigureType.King, Side.Dark, 0, 4);
		AddFigure (FigureType.Queen, Side.Dark, 0, 5);
		AddFigure (FigureType.Knight, Side.Dark, 0, 6);
		AddFigure (FigureType.Bishop, Side.Dark, 0, 7);
		AddFigure (FigureType.Rook, Side.Dark, 0, 8);

		AddFigure (FigureType.Pawn, Side.Light, 8, 4);
		AddFigure (FigureType.Pawn, Side.Light, 8, 5);
		AddFigure (FigureType.Knight, Side.Light, 9, 6);
		AddFigure (FigureType.King, Side.Light, 9, 5);
		AddFigure (FigureType.Queen, Side.Light, 9, 4);
		AddFigure (FigureType.Knight, Side.Light, 9, 3);
		AddFigure (FigureType.Bishop, Side.Light, 9, 2);
		AddFigure (FigureType.Rook, Side.Light, 9, 1);
	}

	void AddFigure(FigureType figureType, Side side, int rowIndex, int colIndex) {
		_cellsArray [rowIndex, colIndex].AddFigure (figureType, side);
	}

	bool isCoordinateOk (int rowIndex, int colIndex) {
		return !((rowIndex < 0) | (rowIndex > dimension - 1) | (colIndex < 0) | (colIndex > dimension - 1));
	}
}
