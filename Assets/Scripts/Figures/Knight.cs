using UnityEngine;
using System.Collections;

public class Knight : Figure {
	void Start () {
		moveModel = new KnightMoveModel ();
	}
}
