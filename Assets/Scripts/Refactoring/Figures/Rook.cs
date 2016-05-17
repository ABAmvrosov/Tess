using UnityEngine;
using System.Collections;

public class Rook : FigureR {
	void OnMouseDown() {
		PossibleMoves ();
	}
	void PossibleMoves () {
		Debug.Log ("Possible Moves: Rook");
	}
}
