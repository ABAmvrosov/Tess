using UnityEngine;
using System.Collections;

public class Bishop : Figure {	
	void Start () {
		moveModel = new BishopMoveModel ();
	}
}
