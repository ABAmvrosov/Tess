using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	public bool PossibleMove { 
		get { return _possibleMove; } 
		set { _possibleMove = value; } 
	}
	public TileType Type {
		get { return _type; }
		set { _type = value; }
	}
	public Figure Figure {
		get { return _figure; }
		set { _figure = value; }
	}

	private bool _possibleMove;
	private TileType _type;
	private Figure _figure;

	private SpriteRenderer _spriteRenderer;
    
	void Awake () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		Messenger.AddListener ("NextTurn", OnFigureMove);
	}

	void OnMouseOver () {
		if (!PossibleMove) {
			Highlight ();
		}
	}

	void OnMouseDown () {
        StateContext context = new StateContext(this, StateMark.MoveToTile);
        GameManager.GM.HandleActionByState(context);			
	}

	void OnMouseExit () {
		if (!PossibleMove) {
			UnHighlight ();
		}
	}
    
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
		switch (this.Type) {
		case TileType.Black:
			return Side.Black;
		case TileType.White:
			return Side.White;
		default:
			return Side.Undefined;
		}
	}
    
	void OnFigureMove () {
		if (PossibleMove) {
			PossibleMove = false;
			UnHighlight ();
		}
	}
}
