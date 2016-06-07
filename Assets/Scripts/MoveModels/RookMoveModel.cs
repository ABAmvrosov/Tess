public class RookMoveModel : MoveModel {
	private int[,] _defaultMoves = {{0,1},{0,-1},{1,0},{-1,0}};
	private int[,] _bonusMoves = {{0,1},{0,-1},{1,0},{-1,0}}; // = _defaultMoves

	public RookMoveModel () {
		IsFixed = false;
	}

	public override int[,] GetModel (bool isBonusMoves) {
		if (isBonusMoves) {
			return _bonusMoves;
		} else
			return _defaultMoves;
	}
}
