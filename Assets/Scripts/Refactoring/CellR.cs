using UnityEngine;
using System.Collections;

public class CellR : MonoBehaviour {
	public GameObject figure;
	private TileType tileType;

	public void InstantiateFigure(FigureType figureType, Side side) {
		if (side == Side.Dark)
			InstantiateFigureBlack (figureType);
		else
			InstantiateFigureWhite (figureType);
	}

	public void SetTileType(TileType tileType) {		
		this.tileType = tileType;
		this.GetComponent<SpriteRenderer> ().sprite = GameManagerR.gm.resourses.GetTileImage(tileType);			
	}

	public TileType GetTileType () {
		return this.tileType;
	}

	public void Highlight () {
		this.GetComponent<SpriteRenderer> ().color = Color.green;
	}

	public void UnHighlight () {
		this.GetComponent<SpriteRenderer> ().color = Color.white;
	}

	void InstantiateFigureBlack (FigureType figureType) {
		switch (figureType) {
		case FigureType.Pawn:
			figure = Instantiate (Resources.Load ("Figures/Black/PawnBlack"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Pawn> ().side = Side.Dark;
			break;
		case FigureType.Bishop:
			figure = Instantiate (Resources.Load ("Figures/Black/BishopBlack"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Bishop> ().side = Side.Dark;
			break;
		case FigureType.Rook:
			figure = Instantiate (Resources.Load ("Figures/Black/RookBlack"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Rook> ().side = Side.Dark;
			break;
		case FigureType.King:
			figure = Instantiate (Resources.Load ("Figures/Black/KingBlack"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<King> ().side = Side.Dark;
			break;
		case FigureType.Knight:
			figure = Instantiate (Resources.Load ("Figures/Black/KnightBlack"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Knight> ().side = Side.Dark;
			break;
		case FigureType.Queen:
			figure = Instantiate (Resources.Load ("Figures/Black/QueenBlack"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Queen> ().side = Side.Dark;
			break;
		}
	}

	void InstantiateFigureWhite (FigureType figureType) {
		switch (figureType) {
		case FigureType.Pawn:
			figure = Instantiate (Resources.Load ("Figures/White/PawnWhite"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Pawn> ().side = Side.Light;
			break;
		case FigureType.Bishop:
			figure = Instantiate (Resources.Load ("Figures/White/BishopWhite"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Bishop> ().side = Side.Light;
			break;
		case FigureType.Rook:
			figure = Instantiate (Resources.Load ("Figures/White/RookWhite"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Rook> ().side = Side.Light;
			break;
		case FigureType.King:
			figure = Instantiate (Resources.Load ("Figures/White/KingWhite"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<King> ().side = Side.Light;
			break;
		case FigureType.Knight:
			figure = Instantiate (Resources.Load ("Figures/White/KnightWhite"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Knight> ().side = Side.Light;
			break;
		case FigureType.Queen:
			figure = Instantiate (Resources.Load ("Figures/White/QueenWhite"), this.transform.position, Quaternion.identity) as GameObject;
			figure.transform.SetParent (this.transform);
			figure.AddComponent<Queen> ().side = Side.Light;
			break;
		}
	}
}
