using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	public bool PossibleMove { get; set; }
	public TileType Type;
	public Figure Figure;
	private SpriteRenderer spriteRenderer;

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		EventManager.OnFigureMove += OnFigureMove;
	}

	void OnMouseOver () {
		if (!PossibleMove) {
			Highlight ();
		}
	}

	void OnMouseDown () {
		if (PossibleMove) {
			GameManager.GM.FigureManager.Move (this);
		}
	}

	void OnMouseExit () {
		if (!PossibleMove) {
			UnHighlight ();
		}
	}

	/* --------------- Interface --------------- */

	public void Highlight () {
		spriteRenderer.color = Color.green;
	}

	public void HighlightAttack () {
		spriteRenderer.color = Color.red;
	}

	public void UnHighlight () {
		spriteRenderer.color = Color.white;
	}

	public Side GetTileSide () {
		switch (this.Type) {
		case TileType.Black:
			return Side.Black;
		case TileType.White:
			return Side.White;
		default:
			return Side.Undefined;
		}
	}

	/* ------------- Other methods ------------- */

	void OnFigureMove () {
		if (PossibleMove) {
			PossibleMove = false;
			UnHighlight ();
		}
	}
}
