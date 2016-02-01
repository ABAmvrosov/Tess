using UnityEngine;
using System.Collections;

public class Figure : MonoBehaviour {

	public FigureTypes figureType;
	public bool isActive = false;
	public Cell parentCell;
	public SideType side;

	void Awake () {
		FigureTypeDefine ();
		parentCell = transform.parent.gameObject.GetComponent<Cell> ();;
		if (this.tag == "Dark") {
			side = SideType.DarkSide;
		} else {
			side = SideType.LightSide;
		}
		EventManager.OnFigureMove += ColliderActivate;
		EventManager.CancelFigurePicked  += ColliderActivate;
		EventManager.OnFigurePick += ColliderDeactivate;
		EventManager.OnCardDone += ColliderDeactivate;
	}

	void Update () {
		if (isActive && Input.GetButtonDown("Cancel")) {
			PawnUtil.UnHighlightPossibleMoves (parentCell.transform.position.x, parentCell.transform.position.y);
			GameManager.gm.DropFigure ();
			EventManager.CancelFigurePicked();
		}
	}

	void OnMouseDown () {
		if (!GameManager.gm.figureTaken) {
			GameManager.gm.TakeFigure (this);
			isActive = true;
			switch (figureType) {
			case FigureTypes.Pawn:				
				PawnUtil.PossibleMoves (this);
				break;
			case FigureTypes.Knight:
				KnightUtil.PossibleMoves (this);
				break;
			}
			EventManager.OnFigurePick();
		}
	}

	void ColliderDeactivate () {
		GetComponent<BoxCollider2D> ().enabled = false;
	}

	void ColliderActivate () {
		GetComponent<BoxCollider2D> ().enabled = true;
	}

	void FigureTypeDefine () {
		switch (this.name) {
		case "Pawn":
			figureType = FigureTypes.Pawn;
			break;
		case "Knight":
			figureType = FigureTypes.Knight;
			break;
		case "Bishop":
			figureType = FigureTypes.Bishop;
			break;
		case "Rook":
			figureType = FigureTypes.Rook;
			break;
		case "Queen":
			figureType = FigureTypes.Queen;
			break;
		case "King":
			figureType = FigureTypes.King;
			break;
		}
	}

}
