﻿using UnityEngine;
using System.Collections;

public class GroundCard : MonoBehaviour {

	public GroundCardFigure groundCardFigure;
	public GroundCardType groundCardType;

	void Start () {
		EventManager.OnCardDone += DestroyCard;
	}

	void OnMouseDown () {
		GameManager.gm.groundCard = this;
		GetComponent<SpriteRenderer> ().color = Color.green;
	}

	public void Highlight (Cell cell) {
		switch (groundCardType) {
		case GroundCardType.Invert:
			InvertUtil.Highlight(cell, groundCardFigure);
			break;
		case GroundCardType.Paste:
			PasteUtil.Highlight(cell, groundCardFigure);
			break;
		case GroundCardType.XOR:
			XORUtil.Highlight(cell, groundCardFigure);
			break;
		}
	}

	public void UnHighlight (Cell cell) {
		switch (groundCardType) {
		case GroundCardType.Invert:
			InvertUtil.UnHighlight(cell, groundCardFigure);
			break;
		case GroundCardType.Paste:
			PasteUtil.UnHighlight(cell, groundCardFigure);
			break;
		case GroundCardType.XOR:
			XORUtil.UnHighlight(cell, groundCardFigure);
			break;
		}
	}

	public void GroundEffect (Cell cell) {
		switch (groundCardType) {
		case GroundCardType.Invert:
			InvertUtil.Invert (cell, groundCardFigure);
			break;
		case GroundCardType.Paste:
			PasteUtil.Invert (cell, groundCardFigure);
			break;
		case GroundCardType.XOR:
			XORUtil.Invert (cell, groundCardFigure);
			break;
		}
	}

	void DestroyCard () {
		Destroy (gameObject);
	}
}