public abstract class Board {	
	public abstract Tile GetTile (IntVector2 coordinates);

	protected abstract bool IsValidCoordinates (IntVector2 coordinates);
}
