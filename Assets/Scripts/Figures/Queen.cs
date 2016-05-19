using UnityEngine;
using System.Collections;

public class Queen : Figure {
	protected override void PossibleMoves () {
		if (IsFriendlyTile()) {
			Debug.Log ("Bonus Possible Moves: Rook");
			BonusPossibleMoves ();
		} else {
			Debug.Log ("Default Possible Moves: Rook");
			DefaultPossibleMoves ();
		}
	}
	void DefaultPossibleMoves() {
		int i = 1;
		while (HighlightCell (rowIndex + i, colIndex)) i++;
		i = 1;
		while (HighlightCell (rowIndex - i, colIndex)) i++;
		i = 1;
		while (HighlightCell (rowIndex, colIndex - i)) i++;
		i = 1;
		while (HighlightCell (rowIndex, colIndex + i)) i++;
		i = 1;
		while (HighlightCell (rowIndex + i, colIndex + i)) i++;
		i = 1;
		while (HighlightCell (rowIndex - i, colIndex + i)) i++;
		i = 1;
		while (HighlightCell (rowIndex + i, colIndex - i)) i++;
		i = 1;
		while (HighlightCell (rowIndex - i, colIndex - i)) i++;
	}

	void BonusPossibleMoves() {
		DefaultPossibleMoves ();
	}
}
