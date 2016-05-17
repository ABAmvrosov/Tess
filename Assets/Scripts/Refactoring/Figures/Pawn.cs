using UnityEngine;
using System.Collections;

public class Pawn : FigureR {
	void OnMouseDown() {
		PossibleMoves ();
	}
	void PossibleMoves () {
		Debug.Log ("Possible Moves: Pawn");
		HighlightCell ((int) this.transform.position.x + 1, (int) this.transform.position.y);
		HighlightCell ((int) this.transform.position.x - 1, (int) this.transform.position.y);
		HighlightCell ((int) this.transform.position.x, (int) this.transform.position.y + 1);
		HighlightCell ((int) this.transform.position.x, (int) this.transform.position.y - 1);
	}
}
