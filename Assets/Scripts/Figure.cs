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

	void Awake() {
		EventManager.GameStarted += UpdatePosition;
		EventManager.OnFigureMove += UpdatePosition;
	}

	void OnMouseDown () {		
		GameManager.gm.board.HighlightPossibleMoves (this);
	}

	void OnDestroy () {
		EventManager.OnFigureMove -= UpdatePosition;
	}

	/* --------------- Interface --------------- */

	public bool isEnemy () {
		if (side != GameManager.gm.currentPlayer) {
			return true;
		} else
			return false;
	}

	/* ------------- Other methods ------------- */

	protected void UpdatePosition () {
		RowIndex = (int) this.transform.position.x;
		ColIndex = (int) this.transform.position.y;
	}
}
