using UnityEngine;
using System.Collections;

public class Figure : MonoBehaviour {

	public Side FigureSide { get; set; }
	public MoveModel FigureMoveModel { get; set; }
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
		if (GameManager.GM.CurrentPlayer == FigureSide) {
			GameManager.GM.GameBoard.HighlightPossibleMoves (this);
		}
	}

	void OnDestroy () {
		EventManager.OnFigureMove -= UpdatePosition;
	}

	/* --------------- Interface --------------- */

	public bool IsEnemy () {
		if (FigureSide != GameManager.GM.CurrentPlayer) {
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
