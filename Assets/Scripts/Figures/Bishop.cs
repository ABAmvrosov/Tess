using UnityEngine;
using System.Collections;

public class Bishop : Figure {	
	void Start () {
		FigureMoveModel = new BishopMoveModel ();
	}
}
