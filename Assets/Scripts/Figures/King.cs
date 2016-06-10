public class King : Figure {
	void Start () {
		MovementModel = new KingMoveModel ();
	}

	void OnDisable () {
		if (GameManager.GM)
			Messenger.Broadcast ("KingDead");
	}
}
