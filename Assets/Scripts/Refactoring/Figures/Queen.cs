using UnityEngine;
using System.Collections;

public class Queen : FigureR {
	void OnMouseDown() {
		PossibleMoves ();
	}
	void PossibleMoves () {
		Debug.Log ("Possible Moves: Queen");
	}
}
