using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {
	
	[SerializeField] private int _dimensionOfBoard;
	private FigureFactory _figureFactory;
	private TileFactory _tileFactory;
	private Board _board; 

	void Start() {
		_figureFactory = this.GetComponent<FigureFactory> ();
		_tileFactory = this.GetComponent<TileFactory> ();
		_board = new PrototypeBoard (_dimensionOfBoard, _tileFactory);
		SetupBlackFigures ();
		SetupWhiteFigures ();
		Messenger.Broadcast ("NextTurn");
	}

	private void SetupBlackFigures () {
		AddFigure (FigureType.Pawn, Side.Black, 4, 1);
		AddFigure (FigureType.Pawn, Side.Black, 5, 1);
		AddFigure (FigureType.Knight, Side.Black, 3, 0);
		AddFigure (FigureType.King, Side.Black, 4, 0);
		AddFigure (FigureType.Queen, Side.Black, 5, 0);
		AddFigure (FigureType.Knight, Side.Black, 6, 0);
		AddFigure (FigureType.Bishop, Side.Black, 7, 0);
		AddFigure (FigureType.Rook, Side.Black, 8, 0);
	}

	private void SetupWhiteFigures () {
		AddFigure (FigureType.Pawn, Side.White, 4, 8);
		AddFigure (FigureType.Pawn, Side.White, 5, 8);
		AddFigure (FigureType.Knight, Side.White, 6, 9);
		AddFigure (FigureType.King, Side.White, 5, 9);
		AddFigure (FigureType.Queen, Side.White, 4, 9);
		AddFigure (FigureType.Knight, Side.White, 3, 9);
		AddFigure (FigureType.Bishop, Side.White, 2, 9);
		AddFigure (FigureType.Rook, Side.White, 1, 9);
	}

	protected void AddFigure (FigureType figureType, Side figureSide, int horCoordinateX, int verCoordinateY) {
		GameObject figureObject = _figureFactory.GetFigure (figureType, figureSide) as GameObject;
		figureObject.transform.position = new Vector3 (horCoordinateX, verCoordinateY, -0.1f);
		GameManager.TheFigureManager.RegisterFigure (figureObject.GetComponent<Figure> () , GetTile(horCoordinateX, verCoordinateY));
	}

	public Tile GetTile (int horCoordinateX, int verCoordinateY) {
		return _board.GetTile (horCoordinateX, verCoordinateY);
	}
    
    public void HighlightPossibleMoves (Figure figure) {
		Tile startTile = GetTile(figure.horCoordinateX, figure.verCoordinateY);
		bool bonusMoves = startTile.GetTileSide () == figure.FigureSide;
		int[,] moves = figure.MovementModel.GetModel (bonusMoves);
		if (figure.MovementModel.IsFixed) {
			ShowFixedMoves (figure, moves);
		} else {
			ShowNonFixedMoves (figure, moves);
		}
	}

	private void ShowFixedMoves (Figure figure, int[,] moves) {
		for (int i = 0; i < moves.GetLength (0); i++) {
			HighlightTile (figure.horCoordinateX + moves [i, 0], figure.verCoordinateY + moves [i, 1]);
		}
	}

	private void ShowNonFixedMoves (Figure figure, int[,] moves) {
		for (int i = 0; i < moves.GetLength (0); i++) {
			int nextXCoordinate = figure.horCoordinateX + moves [i, 0];
			int nextYCoordinate = figure.verCoordinateY + moves [i, 1];
			while (HighlightTile (nextXCoordinate, nextYCoordinate)) {
				nextXCoordinate += moves [i, 0];
				nextYCoordinate += moves [i, 1];
			}
		}
	}

	private bool HighlightTile (int horCoordinateX, int verCoordinateY) {
		Tile tile = GetTile(horCoordinateX, verCoordinateY);
		if (tile != null && tile.Type != TileType.Wall) {			
			Figure figureAtDest = tile.Figure;
			return IsAttack (figureAtDest, tile);
		} else {
			return false;
		}
	}

	private bool IsAttack (Figure figureAtDest, Tile tile) {
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