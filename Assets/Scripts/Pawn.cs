using UnityEngine;
using System.Collections;

public class Pawn : Figure {

	void Update () {
		if (isActive && Input.GetButtonDown("Cancel")) {
			PawnUtil.UnHighlightPossibleMoves (parentCell.transform.position.x, parentCell.transform.position.y);
		}
	}

	void OnMouseDown () {
		GameManager.gm.figureForMoveHandler = this;
		isActive = true;
		PawnUtil.PossibleMoves (parentCell.transform.position.x, parentCell.transform.position.y);
	}
}
