using UnityEngine;

public class Tile : MonoBehaviour {
	
	public bool PossibleMove { 
		get { return _possibleMove; } 
		set { _possibleMove = value; }
    }
    private bool _possibleMove;

    public GameSide TileSide {
		get { return _tileSide; }
		set { _tileSide = value; }
    }
    [SerializeField] private GameSide _tileSide;

    public Figure Figure { get; set; }
    
    private SpriteRenderer _spriteRenderer;
    private bool _isMouseOver;

    void Awake () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		Messenger.AddListener ("FigureMoved", OnFigureMove);
        Messenger.AddListener ("NextTurn", UnHighlight);
	}

	void OnMouseOver () {
        if (GameManager.GM.GameState is PlaceGroundState && !_isMouseOver) {
            _isMouseOver = true;
            GameManager.TheBoardController.GroundModelHighlight(true, this);
        } else if (!PossibleMove && !_isMouseOver) {
            _isMouseOver = true;
			Highlight ();
		}
	}

	void OnMouseDown () {
        StateContext context = new StateContext(this, StateMark.Tile);
        GameManager.GM.HandleActionByState(context);			
	}

	void OnMouseExit () {
		if (!PossibleMove) {
            _isMouseOver = false;
			UnHighlight ();
		}
        if (GameManager.GM.GameState is PlaceGroundState) {
            _isMouseOver = false;
            GameManager.TheBoardController.GroundModelHighlight(false, this);
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
    
	void OnFigureMove () {
		if (PossibleMove) {
			PossibleMove = false;
			UnHighlight ();
		}
	}
}
