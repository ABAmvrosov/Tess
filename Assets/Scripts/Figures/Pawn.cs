using UnityEngine;
using System.Collections;

public class Pawn : Figure {
	void Start () {
		FigureMoveModel = new PawnMoveModel ();		
	}
}
