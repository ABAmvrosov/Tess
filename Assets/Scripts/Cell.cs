using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {
	public GameObject figure;
	public bool possibleMove;
	private TileType tileType;
	private SpriteRenderer _spriteRenderer;

	void Awake () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		EventManager.OnFigureMove += OnFigureMove;
	}

	public void AddFigure(FigureType figureType, Side side) {
		if (side == Side.Dark)
			AddFigureBlack (figureType);
		else
			AddFigureWhite (figureType);
	}

	public void SetTileType(TileType tileType) {		
		this.tileType = tileType;
		_spriteRenderer.sprite = GameManager.gm.resourses.GetTileImage(tileType);			
	}

	public TileType GetTileType () {
		return this.tileType;
	}

	public void Highlight () {
		_spriteRenderer.color = Color.green;
	}

	public void UnHighlight () {
		_spriteRenderer.color = Color.white;
	}

	public Side GetCellSide () {
		switch (this.tileType) {
		case TileType.Black:
			return Side.Dark;
		case TileType.White:
			return Side.Light;
		default:
			return Side.Undefined;
		}
	}

	void OnFigureMove () {
		if (possibleMove) {
			possibleMove = false;
			UnHighlight ();
		}
	}

	void OnMouseOver () {
		if (!possibleMove) {
			Highlight ();
		}
	}

	void OnMouseExit () {
		if (!possibleMove) {
			UnHighlight ();
		}
	}

	void OnMouseDown () {
		if (GameManager.gm.IsFigureTaken () && possibleMove) {
			Board.MoveFigure (GameManager.gm.moveFromCell, this);
		}
	}

	void AddFigureBlack (FigureType figureType) {
		switch (figureType) {
		case FigureType.Pawn:
			InstantiateFigure ("Figures/Black/PawnBlack");
			figure.AddComponent<Pawn> ().side = Side.Dark;
			break;
		case FigureType.Bishop:
			InstantiateFigure ("Figures/Black/BishopBlack");
			figure.AddComponent<Bishop> ().side = Side.Dark;
			break;
		case FigureType.Rook:
			InstantiateFigure ("Figures/Black/RookBlack");
			figure.AddComponent<Rook> ().side = Side.Dark;
			break;
		case FigureType.King:
			InstantiateFigure ("Figures/Black/KingBlack");
			figure.AddComponent<King> ().side = Side.Dark;
			break;
		case FigureType.Knight:
			InstantiateFigure ("Figures/Black/KnightBlack");
			figure.AddComponent<Knight> ().side = Side.Dark;
			break;
		case FigureType.Queen:
			InstantiateFigure ("Figures/Black/QueenBlack");
			figure.AddComponent<Queen> ().side = Side.Dark;
			break;
		}
	}

	void AddFigureWhite (FigureType figureType) {
		switch (figureType) {
		case FigureType.Pawn:
			InstantiateFigure ("Figures/White/PawnWhite");
			figure.AddComponent<Pawn> ().side = Side.Light;
			break;
		case FigureType.Bishop:
			InstantiateFigure ("Figures/White/BishopWhite");
			figure.AddComponent<Bishop> ().side = Side.Light;
			break;
		case FigureType.Rook:
			InstantiateFigure ("Figures/White/RookWhite");
			figure.AddComponent<Rook> ().side = Side.Light;
			break;
		case FigureType.King:
			InstantiateFigure ("Figures/White/KingWhite");
			figure.AddComponent<King> ().side = Side.Light;
			break;
		case FigureType.Knight:
			InstantiateFigure ("Figures/White/KnightWhite");
			figure.AddComponent<Knight> ().side = Side.Light;
			break;
		case FigureType.Queen:
			InstantiateFigure ("Figures/White/QueenWhite");
			figure.AddComponent<Queen> ().side = Side.Light;
			break;
		}
	}

	void InstantiateFigure (string prefabPath) {
		Vector3 position = new Vector3 (this.transform.position.x, this.transform.position.y, -0.1f);
		figure = Instantiate (Resources.Load (prefabPath), position, Quaternion.identity) as GameObject;
		figure.transform.SetParent (this.transform);
	}
}
