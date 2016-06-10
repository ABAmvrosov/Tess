public sealed class PrototypeBoard : Board {

	private int _dimensionOfBoard;
	private TileFactory _tileFactory;
	private Tile[,] _tileArray;

	public PrototypeBoard(int dimension, TileFactory tileFactory) {
		_dimensionOfBoard = dimension;
		_tileFactory = tileFactory;
		_tileArray = new Tile[dimension, dimension];

		BuildBoard (dimension);
	} 

	public override Tile GetTile(IntVector2 coordinates) {
		return IsValidCoordinates(coordinates) ? _tileArray [coordinates.x, coordinates.y] : null;
	}

	protected override bool IsValidCoordinates (IntVector2 coordinates) {
        bool isXValid = (coordinates.x >= 0) & (coordinates.x <= _dimensionOfBoard - 1);
        bool isYValid = (coordinates.y >= 0) & (coordinates.y <= _dimensionOfBoard - 1);
        return isXValid & isYValid;
	}

	private void BuildBoard(int dimension) {
		for (int verCoordinateY = 0; verCoordinateY < dimension; verCoordinateY++) {
			ProceedRow (verCoordinateY, dimension);
		}
		AddWalls ();
	}

	private void ProceedRow (int verCoordinateY, int dimension) {
		for (int horCoordinateX = 0; horCoordinateX < dimension; horCoordinateX++) {
			_tileArray [horCoordinateX, verCoordinateY] = CreateTile(horCoordinateX, verCoordinateY);
		}
	}

	private Tile CreateTile (int verCoordinateX, int verCoordinateY) {
		// Like chess board
		if ((verCoordinateX + verCoordinateY) % 2 == 0) {
            return _tileFactory.GetTile(GameSide.White, verCoordinateX, verCoordinateY);
		} else {
            return _tileFactory.GetTile(GameSide.Black, verCoordinateX, verCoordinateY);
		}
	}

	private void AddWalls () {
		int[,] wallsCoordinates = {{0,5},{1,4},{2,4},{3,5},{4,5},{5,4},{6,4},{7,5},{8,5},{9,4}};
		for (int i = 0; i < wallsCoordinates.GetLength(0); i++) {
			int x = wallsCoordinates [i, 0];
			int y = wallsCoordinates [i, 1];
			_tileFactory.SetTileSide(GetTile(new IntVector2(x, y)), GameSide.Neutral);
		}
	}
}