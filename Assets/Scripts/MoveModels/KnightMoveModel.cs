public class KnightMoveModel : MoveModel {
	private int[,] _defaultMoves = {{1,2},{-1,2},{2,1},{-2,1},{1,-2},{-1,-2},{2,-1},{-2,-1}};
	private int[,] _bonusMoves = {{1,2},{-1,2},{2,1},{-2,1},{1,-2},{-1,-2},{2,-1},{-2,-1}, {2,3}, {-2,3},{3,2},{-3,2},{2,-3},{-2,-3},{3,-2},{-3,-2}};

	public KnightMoveModel () {
		IsFixed = true;
	}

	public override int[,] GetModel (bool isBonusMoves) {
		if (isBonusMoves) {
			return _bonusMoves;
		} else
			return _defaultMoves;
	}
}
