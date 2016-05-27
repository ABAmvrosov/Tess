using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FigureFactory : MonoBehaviour {

	[SerializeField] private GameObject _figurePrefab;
	[SerializeField] private GameObject _figureObjectsContainer;
	[SerializeField] private int _figurePoolSize = 20;

	public GameObject FigurePrefab {
		get { return _figurePrefab; }
		set { _figurePrefab = value; }
	}
	public GameObject FigureObjectsContainer {
		get { return _figureObjectsContainer; }
		set { _figureObjectsContainer = value; }
	}

	private Stack<GameObject> figurePool;

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
		FigurePoolInit ();
		Messenger<GameObject>.AddListener ("KillFigure", ReturnToPool);
	}

	/* --------------- Interface --------------- */

	public GameObject GetFigure (FigureType figureType, Side figureSide) {
		GameObject figureObject = null;
		if (figurePool.Count != 0) {
			figureObject = figurePool.Pop();
		} else {
			figureObject = Instantiate (FigurePrefab) as GameObject;
			figureObject.transform.SetParent (FigureObjectsContainer.transform);
		}
		if (figureSide == Side.Black) 
			ConfigureBlack (figureType, figureObject);
		else
			ConfigureWhite (figureType, figureObject);
		return figureObject;
	}

	/* ------------- Other methods ------------- */

	void ReturnToPool (GameObject figureObject) {
		figurePool.Push (figureObject);
	}

	void FigurePoolInit () {
		figurePool = new Stack<GameObject> (_figurePoolSize);
		GameObject figureObject;
		for (int i = 0; i < _figurePoolSize; i++) {
			figureObject = Instantiate (FigurePrefab) as GameObject;
			figureObject.transform.SetParent (FigureObjectsContainer.transform);
			figurePool.Push (figureObject);
		}
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
