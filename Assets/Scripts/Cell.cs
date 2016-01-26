using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

//	[HideInInspector]
	public Figure figureOnCell;

	private TileTypes _tileType; 
	private SpriteRenderer _spriteRenderer;	
	private Sprite _cellType;
	private bool _moveHighlight;

	void Awake() {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		TileTypeDefine ();
		GameManager.gm.board.AddCell (this);
	}

	void Update () {
		CheckChild ();
	}

	public void PossibleMoves (Figure figure) {
		switch (figure.figureType) {
		case FigureTypes.Pawn:
			HighlightCell (GameManager.gm.board.GetCell(transform.position.x + 1f, transform.position.y));
			HighlightCell (GameManager.gm.board.GetCell(transform.position.x - 1f, transform.position.y));
			HighlightCell (GameManager.gm.board.GetCell(transform.position.x, transform.position.y + 1f));
			HighlightCell (GameManager.gm.board.GetCell(transform.position.x, transform.position.y - 1f));
			break;
		}
	}

	void HighlightCell (Cell cell) {
		cell.GetComponent<SpriteRenderer> ().color = Color.green;
		cell._moveHighlight = true;
	}

	void OnMouseEnter() {
		Debug.Log ("I am over " + _tileType);
		_spriteRenderer.color = Color.green;

	}

	void OnMouseOver() {
		_spriteRenderer.color = Color.green;
	}

	void OnMouseExit() {
		if (!_moveHighlight) _spriteRenderer.color = Color.white;
	}

	void TileTypeDefine () {
		switch (_spriteRenderer.sprite.name) 
		{
		case "White":
			_tileType = TileTypes.White;
			break;
		case "black":
			_tileType = TileTypes.Black;
			break;
		case "Wall":
			_tileType = TileTypes.Wall;
			break;
		}
	}

	void CheckChild () {
		foreach (Transform child in transform) {
			if (child.gameObject.layer == 8) {
				figureOnCell = child.gameObject.GetComponent<Figure> ();
			}
		}
	}
}
