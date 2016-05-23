using UnityEngine;
using System.Collections;

public class FigureFactory : MonoBehaviour {

	public GameObject FigurePrefab;
	public GameObject FigureObjectsContainer;

	public GameObject GetFigure (FigureType figureType, Side figureSide) {
		GameObject figure = Instantiate (FigurePrefab) as GameObject;
		figure.transform.SetParent (FigureObjectsContainer.transform);
		if (figureSide == Side.Black) 
			ConfigureBlack (figureType, figure);
		else
			ConfigureWhite (figureType, figure);
		return figure;
	}

	void ConfigureBlack (FigureType figureType, GameObject figureObject) {
		Figure figureComponent = null;
		switch (figureType) {
		case FigureType.Pawn:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Pawn");
			figureComponent = figureObject.AddComponent<Pawn> ();
			break;
		case FigureType.Bishop:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Bishop");
			figureComponent = figureObject.AddComponent<Bishop> ();
			break;
		case FigureType.Rook:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Rook");
			figureComponent = figureObject.AddComponent<Rook> ();
			break;
		case FigureType.King:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/King");
			figureComponent = figureObject.AddComponent<King> ();
			break;
		case FigureType.Knight:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Knight");
			figureComponent = figureObject.AddComponent<Knight> ();
			break;
		case FigureType.Queen:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Queen");
			figureComponent = figureObject.AddComponent<Queen> ();
			break;
		}
		figureComponent.FigureSide = Side.Black;
	}

	void ConfigureWhite (FigureType figureType, GameObject figureObject) {
		Figure figureComponent = null;
		switch (figureType) {
		case FigureType.Pawn:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Pawn");
			figureComponent = figureObject.AddComponent<Pawn> ();
			break;
		case FigureType.Bishop:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Bishop");
			figureComponent = figureObject.AddComponent<Bishop> ();
			break;
		case FigureType.Rook:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Rook");
			figureComponent = figureObject.AddComponent<Rook> ();
			break;
		case FigureType.King:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/King");
			figureComponent = figureObject.AddComponent<King> ();
			break;
		case FigureType.Knight:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Knight");
			figureComponent = figureObject.AddComponent<Knight> ();
			break;
		case FigureType.Queen:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Queen");
			figureComponent = figureObject.AddComponent<Queen> ();
			break;
		}
		figureComponent.FigureSide = Side.White;
	}
}
