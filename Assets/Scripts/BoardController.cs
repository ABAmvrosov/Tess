using UnityEngine;

public class BoardController : MonoBehaviour {
	
	[SerializeField] private int _dimensionOfBoard;
	private FigureFactory _figureFactory;
	private TileFactory _tileFactory;
	private Board _board;

    private void Start() {
		_figureFactory = this.GetComponent<FigureFactory> ();
		_tileFactory = this.GetComponent<TileFactory> ();
		_board = new PrototypeBoard (_dimensionOfBoard, _tileFactory);
        SetupPrototypeBoardFigures();
    }

    private void SetupPrototypeBoardFigures() {
        FigureType[] figures = { FigureType.Pawn, FigureType.Pawn,   FigureType.Pawn,   FigureType.Pawn, FigureType.Pawn, FigureType.Pawn, FigureType.Pawn, FigureType.Pawn, FigureType.Pawn, FigureType.Pawn,
                                 FigureType.Rook, FigureType.Knight, FigureType.Bishop,                  FigureType.King, FigureType.Queen,                 FigureType.Bishop, FigureType.Knight, FigureType.Rook };
        int[,] whiteFiguresCoordinates = { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 }, { 7, 1 }, { 8, 1 }, { 9, 1 },
                                           { 0, 0 }, { 1, 0 }, { 2, 0 },           { 4, 0 }, { 5, 0 },           { 7, 0 }, { 8, 0 }, { 9, 0 } };
        int[,] blackFiguresCoordinates = { { 0, 8 }, { 1, 8 }, { 2, 8 }, { 3, 8 }, { 4, 8 }, { 5, 8 }, { 6, 8 }, { 7, 8 }, { 8, 8 }, { 9, 8 },
                                           { 0, 9 }, { 1, 9 }, { 2, 9 },           { 5, 9 }, { 4, 9 },           { 7, 9 }, { 8, 9 }, { 9, 9 } };
        SetupWhiteFigures(figures, whiteFiguresCoordinates);
        SetupBlackFigures(figures, blackFiguresCoordinates);
    }

    private void SetupWhiteFigures(FigureType[] figures, int[,] coordinates) {
        for (int i = 0; i < figures.Length; i++) {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];
            AddWhiteFigure(figures[i], new IntVector2(x, y));
        }
    }

    private void SetupBlackFigures (FigureType[] figures, int[,] coordinates) {
        for (int i = 0; i < figures.Length; i++) {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];
            AddBlackFigure(figures[i], new IntVector2(x, y));
        }
    }

    public void AddWhiteFigure(FigureType figureType, IntVector2 coordinates) {
        GameObject figureObject = _figureFactory.GetWhiteFigure(figureType, coordinates) as GameObject;
        Figure figureComponent = figureObject.GetComponent<Figure>();
        Tile owner = GetTile(coordinates);
        GameManager.TheFigureManager.RegisterFigure(figureComponent, owner);
    }

    public void AddBlackFigure(FigureType figureType, IntVector2 coordinates) {
        GameObject figureObject = _figureFactory.GetBlackFigure(figureType, coordinates) as GameObject;
        Figure figureComponent = figureObject.GetComponent<Figure>();
        Tile owner = GetTile(coordinates);
        GameManager.TheFigureManager.RegisterFigure(figureComponent, owner);
    }    

	public Tile GetTile (IntVector2 coordinates) {
		return _board.GetTile (coordinates);
	}

    public void GroundModelHighlight(bool highlight, Tile origin) {
        GroundCard card = (GroundCard)GameManager.TheCardManager.ActiveCard;
        int[,] moves = card.GroundModel.GetModel();
        int x = (int)origin.transform.position.x;
        int y = (int)origin.transform.position.y;
        Tile modifiable;
        for (int i = 0; i < moves.GetLength(0); i++) {
            int newX = x + moves[i, 0];
            int newY = y + moves[i, 1];
            modifiable = GetTile(new IntVector2(newX, newY));
            if (modifiable != null) {
                if (highlight)
                    modifiable.Highlight();
                else
                    modifiable.UnHighlight();
            }
        }
    }

    public void PlaceGround(Tile tile) {
        GroundCard card = (GroundCard)GameManager.TheCardManager.ActiveCard;
        GroundOperations operation = card.groundOperation;
        int[,] moves = card.GroundModel.GetModel();
        int x = (int)tile.transform.position.x;
        int y = (int)tile.transform.position.y;
        for (int i = 0; i < moves.GetLength (0); i++) {
            int newX = x + moves[i, 0];
            int newY = y + moves[i, 1];
            PlaceGroundBasedOnType(operation, new IntVector2(newX, newY));
        }
        Messenger.Broadcast("NextTurn");
    }

    private void PlaceGroundBasedOnType(GroundOperations operation, IntVector2 coordinates) {        
        Tile modifiable = GetTile(coordinates);
        switch (operation) {
            case GroundOperations.Invert:
                InvertGround(modifiable);
                break;
            case GroundOperations.Paste:
                PasteGround(modifiable);
                break;
            case GroundOperations.XOR:
                XORGround(modifiable);
                break;
        }
    }

    private void InvertGround(Tile tile) {
        switch (tile.TileSide) {
            case GameSide.Black:
                _tileFactory.SetTileSide(tile, GameSide.White);
                break;
            case GameSide.White:
                _tileFactory.SetTileSide(tile, GameSide.Black);
                break;
        }
    }

    private void PasteGround(Tile tile) {
        GameSide currentSide = GameManager.GM.CurrentPlayer;
        if (currentSide == GameSide.Black) {
            _tileFactory.SetTileSide(tile, GameSide.Black);
        } else {
            _tileFactory.SetTileSide(tile, GameSide.White);
        }
    }

    private void XORGround(Tile tile) {
        GameSide currentSide = GameManager.GM.CurrentPlayer;
        if (tile.TileSide == GameSide.Neutral) {
            PasteGround(tile);
        } else if (currentSide != tile.TileSide) {
            _tileFactory.SetTileSide(tile, GameSide.Neutral);
        }
    }
    
    public void HighlightPossibleMoves (Figure figure) {
		Tile startTile = GetTile(figure.Coordinates);
		bool isBonusMoves = (startTile.TileSide == figure.FigureSide);
		int[,] moves = figure.MovementModel.GetModel (isBonusMoves);
        if (figure.MovementModel.IsFixed) {
            ShowFixedMoves(figure, moves);
        } else {
            ShowNonFixedMoves(figure, moves);
        }
	}

	private void ShowFixedMoves (Figure figure, int[,] moves) {
		for (int i = 0; i < moves.GetLength (0); i++) {
            int x = figure.Coordinates.x + moves[i, 0];
            int y = figure.Coordinates.y + moves[i, 1];
            HighlightableTile (new IntVector2(x, y));
        }
        if (figure.Type == FigureType.Pawn) {
            HighlightPawnAttack(figure);
        } 
    }

    private void HighlightPawnAttack(Figure pawn) {
        int[,] attackMoves = { { -1, 1 }, { 1, 1 }, { -1, -1 }, { 1, -1 }, };
        Tile targetTile = null;
        for (int i = 0; i < attackMoves.GetLength(0); i++) {
            int x = pawn.Coordinates.x + attackMoves[i, 0];
            int y = pawn.Coordinates.y + attackMoves[i, 1];
            targetTile = GetTile(new IntVector2(x, y));
            Figure targetFigure = targetTile.Figure;
            if (targetTile != null && targetFigure != null && targetFigure.IsEnemy()) {
                targetTile.HighlightAttack();
                targetTile.PossibleMove = true;
            }
        }
    }

	private void ShowNonFixedMoves (Figure figure, int[,] moves) {
		for (int i = 0; i < moves.GetLength (0); i++) {
			int nextX = figure.Coordinates.x + moves [i, 0];
			int nextY = figure.Coordinates.y + moves [i, 1];
			while (HighlightableTile (new IntVector2(nextX, nextY))) {
				nextX += moves [i, 0];
				nextY += moves [i, 1];
			}
		}
	}

	private bool HighlightableTile (IntVector2 coordinates) {
		Tile tile = GetTile(coordinates);
		if (tile != null && tile.TileSide != GameSide.Neutral) {
			return IsTileEmpty (tile);
		} else {
			return false;
		}
	}

	private bool IsTileEmpty (Tile tile) {
        Figure figureAtDest = tile.Figure;
        if (figureAtDest != null && figureAtDest.IsEnemy ()) {
			tile.HighlightAttack ();
			tile.PossibleMove = true;
			return false;
		} else if (figureAtDest == null) {
			tile.Highlight ();
			tile.PossibleMove = true;
			return true;
		} else
			return false;
	}    
}