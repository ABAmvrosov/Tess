using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {
	
	public int dimension;
	public CellR cellPrefab;

	private CellR[,] _cellsArray;

	void Awake() {
		InitBoardArray (dimension);
	}

	//Test board,looks like chessboard. Some figures.
	void InitBoardArray(int dimension) {
		_cellsArray = new CellR[dimension, dimension];
		for (int rowIndex = 0; rowIndex < dimension; rowIndex++) {
			GameObject container = new GameObject();
			container.name = "Row" + rowIndex;
			for (int colIndex = 0; colIndex < dimension; colIndex++) {
				CellR cell = Instantiate (cellPrefab, new Vector3 (colIndex, rowIndex, 0f), Quaternion.identity) as CellR;
				cell.transform.SetParent (container.transform);
				if ((rowIndex + colIndex) % 2 == 0) {
					cell.SetTileType(TileType.White);
				} else {
					cell.SetTileType(TileType.Black);
				}
				_cellsArray [rowIndex, colIndex] = cell;
			}
		}
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
		_cellsArray [rowIndex, colIndex].InstantiateFigure (figureType, side);
	}

	public CellR GetCell(int rowIndex, int colIndex) {
		return _cellsArray [colIndex, rowIndex];
	}
}
