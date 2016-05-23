using UnityEngine;
using System.Collections;

public class Knight : Figure {
	void Start () {
		FigureMoveModel = new KnightMoveModel ();
	}
}
