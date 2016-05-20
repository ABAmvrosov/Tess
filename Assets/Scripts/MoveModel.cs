public abstract class MoveModel {
	public abstract void HighlightMoves (Figure figure, Tile startTile);
	protected abstract void DefaultMoves (Figure figure);
	protected abstract void BonusMoves (Figure figure);
}
