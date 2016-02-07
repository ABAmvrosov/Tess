using UnityEngine;
using System.Collections;

public class GroundCard : MonoBehaviour {

	public GroundCardFigure groundCardFigure;
	public GroundCardType groundCardType;

	bool _isTaken;

	void Start () {

	}

	void Update () {
		if (_isTaken && !GameManager.gm.groundCard) {
			Destroy(gameObject);
		}
	}

	void OnMouseDown () {
		GameManager.gm.groundCard = this;
		_isTaken = true;
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
			PasteUtil.Paste (cell, groundCardFigure);
			break;
		case GroundCardType.XOR:
			XORUtil.XOR (cell, groundCardFigure);
			break;
		}
	}

	void DestroyCard () {
		Destroy (gameObject);
	}
}
