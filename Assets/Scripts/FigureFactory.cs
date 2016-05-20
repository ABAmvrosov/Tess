using UnityEngine;
using System.Collections;

public class FigureFactory : MonoBehaviour {

	public GameObject figurePrefab;
	public GameObject figuresContainer;

	public GameObject GetFigure (FigureType figureType, Side side) {
		GameObject figure = Instantiate (figurePrefab) as GameObject;
		figure.transform.SetParent (figuresContainer.transform);
		if (side == Side.Black) 
			ConfigureBlack (figureType, figure);
		else
			ConfigureWhite (figureType, figure);
		return figure;
	}

	void ConfigureBlack (FigureType figureType, GameObject figure) {
		Figure figureComponent = figure.AddComponent<Figure> ();
		figureComponent.side = Side.Black;
		switch (figureType) {
		case FigureType.Pawn:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Pawn");
			figureComponent.moveModel = new PawnMoveModel ();
			break;
		case FigureType.Bishop:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Bishop");
			figureComponent.moveModel = new BishopMoveModel ();
			break;
		case FigureType.Rook:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Rook");
			figureComponent.moveModel = new RookMoveModel ();
			break;
		case FigureType.King:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/King");
			figureComponent.moveModel = new KingMoveModel ();
			break;
		case FigureType.Knight:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Knight");
			figureComponent.moveModel = new KnightMoveModel ();
			break;
		case FigureType.Queen:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Queen");
			figureComponent.moveModel = new QueenMoveModel ();
			break;
		}
	}

	void ConfigureWhite (FigureType figureType, GameObject figure) {
		Figure figureComponent = figure.AddComponent<Figure> ();
		figureComponent.side = Side.White;
		switch (figureType) {
		case FigureType.Pawn:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Pawn");
			figureComponent.moveModel = new PawnMoveModel ();
			break;
		case FigureType.Bishop:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Bishop");
			figureComponent.moveModel = new BishopMoveModel ();
			break;
		case FigureType.Rook:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Rook");
			figureComponent.moveModel = new RookMoveModel ();
			break;
		case FigureType.King:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/King");
			figureComponent.moveModel = new KingMoveModel ();
			break;
		case FigureType.Knight:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Knight");
			figureComponent.moveModel = new KnightMoveModel ();
			break;
		case FigureType.Queen:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Queen");
			figureComponent.moveModel = new QueenMoveModel ();
			break;
		}
	}
}
