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

	public override Tile GetTile(int horCoordinateX, int verCoordinateY) {
		return IsValidCoordinates(horCoordinateX, verCoordinateY) ? _tileArray [horCoordinateX, verCoordinateY] : null;
	}

	protected override bool IsValidCoordinates (int horCoordinateX, int verCoordinateY) {
        bool isXValid = (horCoordinateX >= 0) & (horCoordinateX <= _dimensionOfBoard - 1);
        bool isYValid = (verCoordinateY >= 0) & (verCoordinateY <= _dimensionOfBoard - 1);
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
            return _tileFactory.GetTile(TileType.White, verCoordinateX, verCoordinateY);
		} else {
            return _tileFactory.GetTile(TileType.Black, verCoordinateX, verCoordinateY);
		}
	}

	private void AddWalls () {
		int[,] wallsCoordinates = {{0,5},{1,4},{2,4},{3,5},{4,5},{5,4},{6,4},{7,5},{8,5},{9,4}};
		for (int i = 0; i < wallsCoordinates.GetLength(0); i++) {
			int horCoordinateX = wallsCoordinates [i, 0];
			int verCoordinateY = wallsCoordinates [i, 1];
			_tileFactory.SetTileType(GetTile(horCoordinateX, verCoordinateY), TileType.Wall);
		}
	}
}