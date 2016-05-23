using UnityEngine;
using System.Collections;

public class Queen : Figure {
	void Start () {
		moveModel = new QueenMoveModel ();
	}
}
