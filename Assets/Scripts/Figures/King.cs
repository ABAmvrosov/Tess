using UnityEngine;
using System.Collections;

public class King : Figure {
	void Start () {
		MovementModel = new KingMoveModel ();
	}

	void OnDisable () {
//		Debug.Log ("King dead");
		if (GameManager.GM)
			Messenger.Broadcast ("KingDead");
	}
}
