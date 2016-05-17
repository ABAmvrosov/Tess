using UnityEngine;
using System.Collections;

public class King : FigureR {
	void OnMouseDown() {
		PossibleMoves ();
	}
	void PossibleMoves () {
		Debug.Log ("Possible Moves: King");
	}
}
