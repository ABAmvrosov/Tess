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
		return cellArray [ToIndices (x), ToIndices (y)];
	}
	int ToIndices(float coordinate) {
		return (int)coordinate + dimension / 2;
	}
}
