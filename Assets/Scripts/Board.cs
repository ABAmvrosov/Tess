using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Board : MonoBehaviour {

	[SerializeField]
	protected GameObject _tileObjectsContainer;

	/* ---------- MonoBehavior methods ---------- */

	void Start() {
		if (_tileObjectsContainer == null)
			Debug.LogWarning ("Tile Objects Container not specified");
		InitializeBoard ();
	}

	/* --------------- Interface --------------- */

	public abstract Tile GetTile (int rowIndex, int colIndex);
	public abstract void HighlightPossibleMoves (Figure figure);
	public abstract bool HighlightTile (int rowIndex, int colIndex);

	/* ------------- Other methods ------------- */

	protected abstract void InitializeBoard();

	protected abstract void AddFigure (FigureType figureType, Side figureSide, int rowIndex, int colIndex);

	protected abstract bool CheckCoordinate (int rowIndex, int colIndex);
}
