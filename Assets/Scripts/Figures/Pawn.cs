using UnityEngine;
using System.Collections;

public class Pawn : Figure {
	void Start () {
		moveModel = new PawnMoveModel ();		
	}
}
