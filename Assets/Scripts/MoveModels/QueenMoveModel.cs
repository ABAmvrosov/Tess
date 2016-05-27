public class QueenMoveModel : MoveModel {
	private int[,] _defaultMoves = {{-1,1},{1,1},{1,-1},{-1,-1},{0,1},{0,-1},{1,0},{-1,0}};
	private int[,] _bonusMoves = {{-1,1},{1,1},{1,-1},{-1,-1},{0,1},{0,-1},{1,0},{-1,0}}; // = _defaultMoves

	public QueenMoveModel () {
		IsFixedMoveModel = false;
	}

	public override int[,] GetModel (bool isBonusMoves) {
		if (isBonusMoves) {
			return _bonusMoves;
		} else
			return _defaultMoves;
	}
}
