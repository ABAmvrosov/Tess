﻿public class KingMoveModel : MoveModel {
	private int[,] moves = {{0,1},{1,1},{1,0},{1,-1},{0,-1},{-1,-1},{-1,0},{-1,1}};
//	private int[,] bonusMoves = {};

	public override void HighlightMoves (Figure figure, Tile tile) {
		if (tile.GetTileSide () != figure.side) {
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
	}
}