using UnityEngine;
using System.Collections;

public class Figure : MonoBehaviour {

	[HideInInspector]
	public FigureTypes figureType;

	SideType _side;
	Cell _parentCell;

	void Awake () {
		FigureTypeDefine ();
		_parentCell = transform.parent.gameObject.GetComponent<Cell> ();;
		if (this.tag == "Dark") {
			_side = SideType.DarkSide;
		} else {
			_side = SideType.LightSide;
		}
	}

	void OnMouseDown () {
		_parentCell.PossibleMoves(this);
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
