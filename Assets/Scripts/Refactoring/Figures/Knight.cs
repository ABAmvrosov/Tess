using UnityEngine;
using System.Collections;

public class Knight : FigureR {
	void OnMouseDown() {
		PossibleMoves ();
	}
	void PossibleMoves () {
		Debug.Log ("Possible Moves: Knight");
	}
}
