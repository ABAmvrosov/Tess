﻿public class RookMoveModel : MoveModel {
	private int[,] moves = {{0,1},{0,-1},{1,0},{-1,0}};
	private int[,] bonusMoves = {};

	public override void HighlightMoves (Figure figure, Tile tile) {
		if (tile.GetCellSide () != figure.side) {
			DefaultMoves (figure);
		} else {
			BonusMoves (figure);
		}
	}

	protected override void DefaultMoves (Figure figure) {
		for (int i = 0; i < moves.GetLength (0); i++) {
			int x = (int) figure.transform.position.x; 
			int y = (int) figure.transform.position.y;
			while (GameManager.gm.board.HighlightTile (x + moves[i, 0], y + moves [i, 1])) {
				x += moves [i, 0];
				y += moves [i, 1];
			}
		}
	}

	protected override void BonusMoves (Figure figure) {
		DefaultMoves (figure);
	}
}
