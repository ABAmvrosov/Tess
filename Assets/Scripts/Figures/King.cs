using UnityEngine;
using System.Collections;

public class King : Figure {
	protected override void PossibleMoves () {
		if (IsFriendlyTile()) {
			Debug.Log ("Bonus Possible Moves: King");
			BonusPossibleMoves ();
		} else {
			Debug.Log ("Default Possible Moves: King");
			DefaultPossibleMoves ();
		}
	}
	void DefaultPossibleMoves() {
		for (int i = -1; i < 2; i++) {
			for (int j = -1; j < 2; j++) {
				if (i == 0 & j == 0) {
					/*NOP*/
				} else {
					HighlightCell (rowIndex + i, colIndex + j);
				}
			}
		}
	}

	void BonusPossibleMoves() {
		DefaultPossibleMoves ();
	}
}
