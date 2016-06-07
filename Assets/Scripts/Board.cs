using System.Collections;
using System.Collections.Generic;

public abstract class Board {	
	public abstract Tile GetTile (int rowIndex, int colIndex);

	protected abstract bool CheckCoordinate (int rowIndex, int colIndex);
}
