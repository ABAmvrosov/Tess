using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

//	[HideInInspector]
//	public Figure figureOnCell;
	public bool moveHighlightOn;
	public TileTypes tileType; 

	private SpriteRenderer _spriteRenderer;	
	private Sprite _cellType;
	private FigureTypes _figureType;

	void Start() {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		TileTypeDefine ();
		GameManager.gm.board.AddCell (this);

	}

	void Update () {
//		CheckChild ();
	}

	void OnMouseDown() {
		if (GameManager.gm.figureForMoveHandler != null && moveHighlightOn) {
			GameManager.gm.figureForMoveHandler.parentCell.UnHighlightPossibleMoves();
			GameManager.gm.figureForMoveHandler.parentCell = this;
			GameManager.gm.figureForMoveHandler.transform.position = this.transform.position;
			GameManager.gm.figureForMoveHandler = null;
		}
	}

	void OnMouseOver() {
//		Debug.Log ("I am over " + tileType);
		_spriteRenderer.color = Color.green;
	}

	void OnMouseExit() {
		if (!moveHighlightOn) _spriteRenderer.color = Color.white;
	}

	void TileTypeDefine () {
		switch (_spriteRenderer.sprite.name) 
		{
		case "White":
			tileType = TileTypes.White;
			break;
		case "black":
			tileType = TileTypes.Black;
			break;
		case "Wall":
			tileType = TileTypes.Wall;
			break;
		}
	}
	
	void UnHighlightPossibleMoves () {
		switch (_figureType) {
		case FigureTypes.Pawn:
			PawnUtil.UnHighlightPossibleMoves (transform.position.x, transform.position.y);
			break;
		}
	}

	void CheckChild () {
		foreach (Transform child in transform) {
			switch (child.gameObject.name) {
			case "Pawn":
				_figureType = FigureTypes.Pawn;
				break;
			}
		}
	}
}
