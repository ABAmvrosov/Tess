public class BishopMoveModel : MoveModel {
	private int[,] _defaultMoves = {{-1,1},{1,1},{1,-1},{-1,-1}};
	private int[,] _bonusMoves = {{-1,1},{1,1},{1,-1},{-1,-1}}; // = _defaultMoves

	public BishopMoveModel () {
		IsFixed = false;
	}

	public override int[,] GetModel (bool isBonusMoves) {
		if (isBonusMoves) {
			return _bonusMoves;
		} else
			return _defaultMoves;
	}
}
