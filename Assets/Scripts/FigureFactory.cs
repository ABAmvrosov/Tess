using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FigureFactory : MonoBehaviour {

	[SerializeField] private int _figurePoolSize = 20;

	public GameObject FigurePrefab {
		get { return _figurePrefab; }
		set { _figurePrefab = value; }
    }
    [SerializeField] private GameObject _figurePrefab;

    public GameObject FigureObjectsContainer {
		get { return _figureObjectsContainer; }
		set { _figureObjectsContainer = value; }
	}
    [SerializeField] private GameObject _figureObjectsContainer;

    private Stack<GameObject> figurePool;
    
	void Awake () {
		FigurePoolInit ();
		Messenger<GameObject>.AddListener ("KillFigure", ReturnToPool);
    }

    void FigurePoolInit()
    {
        figurePool = new Stack<GameObject>(_figurePoolSize);
        GameObject figureObject;
        for (int i = 0; i < _figurePoolSize; i++)
        {
            figureObject = Instantiate(FigurePrefab) as GameObject;
            figureObject.transform.SetParent(FigureObjectsContainer.transform);
            figureObject.name = "FigureInPool";
            figurePool.Push(figureObject);
        }
    }

    void ReturnToPool(GameObject figureObject)
    {
        figurePool.Push(figureObject);
    }

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
        
	void ConfigureBlack (FigureType figureType, GameObject figureObject) {
		Figure figureComponent = null;
		switch (figureType) {
		case FigureType.Pawn:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Pawn");
			figureComponent = figureObject.AddComponent<Pawn> ();
            figureComponent.Type = FigureType.Pawn;
            figureObject.name = "Black-Pawn";
			break;
		case FigureType.Bishop:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Bishop");
			figureComponent = figureObject.AddComponent<Bishop> ();
            figureComponent.Type = FigureType.Bishop;
            figureObject.name = "Black-Bishop";
            break;
		case FigureType.Rook:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Rook");
			figureComponent = figureObject.AddComponent<Rook> ();
            figureComponent.Type = FigureType.Rook;
            figureObject.name = "Black-Rook";
			break;
		case FigureType.King:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/King");
			figureComponent = figureObject.AddComponent<King> ();
            figureComponent.Type = FigureType.King;
            figureObject.name = "Black-King";
			break;
		case FigureType.Knight:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Knight");
			figureComponent = figureObject.AddComponent<Knight> ();
            figureComponent.Type = FigureType.Knight;
            figureObject.name = "Black-Knight";
			break;
		case FigureType.Queen:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/Black/Queen");
			figureComponent = figureObject.AddComponent<Queen> ();
            figureComponent.Type = FigureType.Queen;
            figureObject.name = "Black-Queen";
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
            figureComponent.Type = FigureType.Pawn;
            figureObject.name = "White-Pawn";
			break;
		case FigureType.Bishop:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Bishop");
			figureComponent = figureObject.AddComponent<Bishop> ();
            figureComponent.Type = FigureType.Bishop;
            figureObject.name = "White-Bishop";
			break;
		case FigureType.Rook:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Rook");
			figureComponent = figureObject.AddComponent<Rook> ();
            figureComponent.Type = FigureType.Rook;
            figureObject.name = "White-Rook";
			break;
		case FigureType.King:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/King");
			figureComponent = figureObject.AddComponent<King> ();
            figureComponent.Type = FigureType.King;
            figureObject.name = "White-King";
			break;
		case FigureType.Knight:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Knight");
			figureComponent = figureObject.AddComponent<Knight> ();
            figureComponent.Type = FigureType.Knight;
            figureObject.name = "White-Knight";
			break;
		case FigureType.Queen:
			figureObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/Figures/White/Queen");
			figureComponent = figureObject.AddComponent<Queen> ();
            figureComponent.Type = FigureType.Queen;
            figureObject.name = "White-Queen";
			break;
		}
		figureComponent.FigureSide = Side.White;
	}
}
