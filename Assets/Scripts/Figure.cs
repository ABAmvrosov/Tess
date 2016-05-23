using UnityEngine;
using System.Collections;

public class Figure : MonoBehaviour {

	public Side side;
	public MoveModel moveModel;
	public int RowIndex {
		get;
		private set;
	}
	public int ColIndex {
		get;
		private set;
	}


	/* ---------- MonoBehavior methods ---------- */

	void Start() {
		UpdatePosition ();
		EventManager.OnFigureMove += UpdatePosition;
	}

	void OnMouseDown () {		
		GameManager.gm.board.HighlightPossibleMoves (this);
	}

	/* --------------- Interface --------------- */

	public bool isEnemy () {
		if (side != GameManager.gm.currentPlayer) {
			return true;
		} else
			return false;
	}

	/* ------------- Other methods ------------- */

	void UpdatePosition () {
		RowIndex = (int) this.transform.position.x;
		ColIndex = (int) this.transform.position.y;
	}
}
