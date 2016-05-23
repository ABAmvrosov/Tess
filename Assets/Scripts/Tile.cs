﻿using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	public bool possibleMove;
	public TileType type;
	public Figure figure;
	private SpriteRenderer _spriteRenderer;

	/* ---------- MonoBehavior methods ---------- */

	void Awake () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		EventManager.OnFigureMove += OnFigureMove;
	}

	void OnMouseOver () {
		if (!possibleMove) {
			Highlight ();
		}
	}

	void OnMouseDown () {
		if (possibleMove) {
			GameManager.gm.figureManager.MoveFigure (this);
		}
	}

	void OnMouseExit () {
		if (!possibleMove) {
			UnHighlight ();
		}
	}

	/* --------------- Interface --------------- */

	public void Highlight () {
		_spriteRenderer.color = Color.green;
	}

	public void HighlightAttack () {
		_spriteRenderer.color = Color.red;
	}

	public void UnHighlight () {
		_spriteRenderer.color = Color.white;
	}

	public Side GetTileSide () {
		switch (this.type) {
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
		if (possibleMove) {
			possibleMove = false;
			UnHighlight ();
		}
	}
}