using UnityEngine;
using System.Collections;

public class Rook : Figure {
	void Start () {
		MovementModel = new RookMoveModel ();
	}
}
