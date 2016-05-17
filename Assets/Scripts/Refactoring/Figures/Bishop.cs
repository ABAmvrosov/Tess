using UnityEngine;
using System.Collections;

public class Bishop : FigureR {
	void OnMouseDown() {
		PossibleMoves ();
	}
	void PossibleMoves () {
		Debug.Log ("Possible Moves: Bishop");
	}
}
