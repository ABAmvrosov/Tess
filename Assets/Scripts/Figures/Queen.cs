using UnityEngine;
using System.Collections;

public class Queen : Figure {
	void Start () {
		MovementModel = new QueenMoveModel ();
	}
}
