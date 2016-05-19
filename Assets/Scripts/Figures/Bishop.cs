using UnityEngine;
using System.Collections;

public class Bishop : Figure {	
	protected override void PossibleMoves () {
		if (IsFriendlyTile()) {
			Debug.Log ("Bonus Possible Moves: Bishop");
			BonusPossibleMoves ();
		} else {
			Debug.Log ("Default Possible Moves: Bishop");
			DefaultPossibleMoves ();
		}
	}
	void DefaultPossibleMoves() {
		int i = 1;
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
