using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public Cell[,] cellArray;
	public int dimension;
//	public int rows;
//	public int columns;

	void Awake() {
		cellArray = new Cell[dimension, dimension];
	}

	public void AddCell(Cell cell) {
		cellArray [ToIndices(cell.transform.position.x), ToIndices(cell.transform.position.y)] = cell;
	}

	public Cell GetCell (float x, float y) {
		if (isCoordinateOk (x, y)) {
			return cellArray [ToIndices (x), ToIndices (y)];
		} else {
			return null;
		}
	}

	int ToIndices(float coordinate) {
		return (int)coordinate + dimension / 2;
	}

	public static bool isCoordinateOk (float x, float y) {
		int highBorder = GameManager.gm.board.dimension/2;
		int lowerBorder = highBorder * -1;
		return !(x >= highBorder | x < lowerBorder | y >= highBorder | y < lowerBorder);
	}
}
