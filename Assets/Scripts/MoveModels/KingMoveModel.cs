public class KingMoveModel : MoveModel {
	private int[,] _defaultMoves = {{0,1},{1,1},{1,0},{1,-1},{0,-1},{-1,-1},{-1,0},{-1,1}};
	private int[,] _bonusMoves = {{0,1},{1,1},{1,0},{1,-1},{0,-1},{-1,-1},{-1,0},{-1,1}}; // = _defaultMoves

	public KingMoveModel () {
		IsFixed = true;
	}

	public override int[,] GetModel (bool isBonusMoves) {
		if (isBonusMoves) {
			return _bonusMoves;
		} else
			return _defaultMoves;
	}
}
