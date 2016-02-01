using UnityEngine;
using System.Collections;

// This class represent a single Cell on the board
public class Cell : MonoBehaviour {

	// public variables
	public bool moveHighLightOn;  // used for define possible cells to move figure
	public TileTypes tileType;    // Define a type of cell
	public Figure figure;		  // Stores figure on it, if not then null

	//private variables
	private SpriteRenderer _spriteRenderer;	// used for highligh possible moves
	private Sprite _cellType;				// used for define tileType variable

	void Start() {

		_spriteRenderer = GetComponent<SpriteRenderer> ();
		TileTypeDefine ();
		CheckChild ();

		// add cell to board 2d array
		GameManager.gm.board.AddCell (this);
	}

	void Update () {
	}

	void OnMouseOver() {
		if (GameManager.gm.groundCard) {
			GameManager.gm.groundCard.Highlight (this);
		} 
		if (!GameManager.gm.groundCard && !moveHighLightOn)
			_spriteRenderer.color = Color.green;

	}

	void OnMouseExit() {
		if (GameManager.gm.groundCard) {
			GameManager.gm.groundCard.UnHighlight (this);
		} else if (!moveHighLightOn) 
			_spriteRenderer.color = Color.white;
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
	
	// called for move figure
	void OnMouseDown() {
		if (GameManager.gm.figureTaken && moveHighLightOn) {
			if (figure) {
				Figure pickedFigure = GameManager.gm.figureForMoveHandler;
				GameManager.gm.DropFigure ();
				PawnUtil.Attack (figure);
				MoveFigure (pickedFigure);				
				EventManager.OnFigureMove();
			} else {
				Figure pickedFigure = GameManager.gm.figureForMoveHandler;
				GameManager.gm.DropFigure ();
				MoveFigure (pickedFigure);
				EventManager.OnFigureMove();
			}
		}
		if (GameManager.gm.groundCard) {
			GameManager.gm.groundCard.GroundEffect (this);
			GameManager.gm.groundCard = null;
			EventManager.OnCardDone();
		}
	}	

	void MoveFigure (Figure f) {
		f.parentCell.UnHighlight();
		Cell oldCell = f.parentCell;
		f.parentCell = this;
		oldCell.figure = null;
		f.transform.position = this.transform.position;
		figure = f;
		_spriteRenderer.color = Color.white;
		f = null;
	}

	void UnHighlight () {
		switch (figure.figureType) {
		case FigureTypes.Pawn:
			PawnUtil.UnHighlightPossibleMoves (transform.position.x, transform.position.y);
			break;
		case FigureTypes.Knight:
			KnightUtil.UnHighlightPossibleMoves (transform.position.x, transform.position.y);
			break;
		}
	}

	void CheckChild () {
		if (transform.childCount == 0)
			return;
		foreach (Transform child in transform) {

			figure = child.gameObject.GetComponent<Figure>();

		}
	}

	void DropFigure () {
		figure = null; 
	}
}
