public class Queen : Figure {
	void Start () {
		MovementModel = new QueenMoveModel ();
	}
}
