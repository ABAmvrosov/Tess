using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Board : MonoBehaviour {

	[SerializeField]
	protected GameObject tileContainer;
	/* ---------- MonoBehavior methods ---------- */

	void Start() {
		InitializeBoard ();
	}

	/* --------------- Interface --------------- */

	public abstract Tile GetTile (int rowIndex, int colIndex);
	public abstract void HighlightPossibleMoves (Figure figure);
	public abstract bool HighlightTile (int rowIndex, int colIndex);

	/* ------------- Other methods ------------- */

	protected abstract void InitializeBoard();

	protected abstract void AddFigure (FigureType figureType, Side side, int rowIndex, int colIndex);

	protected abstract bool isCoordinateOk (int rowIndex, int colIndex);
}
