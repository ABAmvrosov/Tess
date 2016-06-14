public class PawnMoveModel : MoveModel {


    private int[,] _defaultMoves = { { 0, 1 }, { 0, -1 }, /*{ 1, 0 }, { -1, 0 }*/};
    private int[,] _bonusMoves = { { 0, 1 }, { 0, -1 }, { 0, 2 }, { 0, -2 }, /*{ 1, 0 }, { -1, 0 }, { 2, 0 }, { -2, 0 }*/ };

	public PawnMoveModel () {
		IsFixed = true;
	}

	public override int[,] GetModel (bool isBonusMoves) {
		if (isBonusMoves) {
			return _bonusMoves;
		} else
			return _defaultMoves;
	}
}
