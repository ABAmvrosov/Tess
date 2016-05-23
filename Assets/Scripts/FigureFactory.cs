using UnityEngine;
using System.Collections;

public class FigureFactory : MonoBehaviour {

	public GameObject figurePrefab;
	public GameObject figureObjectsContainer;

	public GameObject GetFigure (FigureType figureType, Side side) {
		GameObject figure = Instantiate (figurePrefab) as GameObject;
		figure.transform.SetParent (figureObjectsContainer.transform);
		if (side == Side.Black) 
			ConfigureBlack (figureType, figure);
		else
			ConfigureWhite (figureType, figure);
		return figure;
	}

	void ConfigureBlack (FigureType figureType, GameObject figure) {
		Figure figureComponent = null;
		switch (figureType) {
		case FigureType.Pawn:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Pawn");
			figureComponent = figure.AddComponent<Pawn> ();
			break;
		case FigureType.Bishop:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Bishop");
			figureComponent = figure.AddComponent<Bishop> ();
			break;
		case FigureType.Rook:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Rook");
			figureComponent = figure.AddComponent<Rook> ();
			break;
		case FigureType.King:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/King");
			figureComponent = figure.AddComponent<King> ();
			break;
		case FigureType.Knight:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Knight");
			figureComponent = figure.AddComponent<Knight> ();
			break;
		case FigureType.Queen:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Queen");
			figureComponent = figure.AddComponent<Queen> ();
			break;
		}
		figureComponent.side = Side.Black;
	}

	void ConfigureWhite (FigureType figureType, GameObject figure) {
		Figure figureComponent = null;
		switch (figureType) {
		case FigureType.Pawn:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Pawn");
			figureComponent = figure.AddComponent<Pawn> ();
			break;
		case FigureType.Bishop:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Bishop");
			figureComponent = figure.AddComponent<Bishop> ();
			break;
		case FigureType.Rook:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Rook");
			figureComponent = figure.AddComponent<Rook> ();
			break;
		case FigureType.King:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/King");
			figureComponent = figure.AddComponent<King> ();
			break;
		case FigureType.Knight:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Knight");
			figureComponent = figure.AddComponent<Knight> ();
			break;
		case FigureType.Queen:
			figure.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Queen");
			figureComponent = figure.AddComponent<Queen> ();
			break;
		}
		figureComponent.side = Side.White;
	}
}
