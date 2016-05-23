using UnityEngine;
using System.Collections;

public class King : Figure {
	void Start () {
		moveModel = new KingMoveModel ();
	}

	void OnDestroy () {
		Debug.Log ("King dead");
		EventManager.KingDead ();
	}
}
