public class PawnMoveModel : MoveModel {
	private int[,] moves = {{0,1},{0,-1},{1,0},{-1,0}};
	private int[,] bonusMoves = {{0,2},{0,-2},{2,0},{-2,0}};

	public override void HighlightMoves (Figure figure, Tile tile) {
		if (tile.GetCellSide () != figure.side) {
			DefaultMoves (figure);
		} else {
			BonusMoves (figure);
		}
	}

	protected override void DefaultMoves (Figure figure) {
		for (int i = 0; i < moves.GetLength (0); i++) {
			GameManager.gm.board.HighlightTile ((int)figure.transform.position.x + moves [i, 0], (int)figure.transform.position.y + moves [i, 1]);
		}

	}

	protected override void BonusMoves (Figure figure) {
		DefaultMoves (figure);
		for (int i = 0; i < bonusMoves.GetLength (0); i++) {
			GameManager.gm.board.HighlightTile ((int) figure.transform.position.x + bonusMoves [i, 0], (int) figure.transform.position.y + bonusMoves [i, 1]);
		}
	}
}
