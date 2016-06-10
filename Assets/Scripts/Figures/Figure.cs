using UnityEngine;

public class Figure : MonoBehaviour {

	public GameSide FigureSide { get; set; }
    public FigureType Type { get; set; }
	public MoveModel MovementModel { get; set; }
    public IntVector2 Coordinates { get; private set; }
    public bool CanMove {
        get {
            return _canMove;
        }
        set {
            _canMove = value;
            if (value)
                Highlight();
            else
                UnHighlight();
        }
    }
    private bool _canMove;

    protected SpriteRenderer _spriteRenderer;


    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetCoordinates();
        Messenger.AddListener("NextTurn", UpdatePosition);
    }

    private void SetCoordinates() {
        Coordinates = new IntVector2((int)this.transform.position.x, (int)this.transform.position.y);
    }

    protected void UpdatePosition() {
        if (CanMove) {
            CanMove = false;
            SetCoordinates();
        }
    }

    private void OnDisable() {
        Messenger.RemoveListener("NextTurn", UpdatePosition);
        Messenger<GameObject>.Broadcast("KillFigure", this.gameObject);
    }

    public bool IsEnemy() {
        if (FigureSide != GameManager.GM.CurrentPlayer) {
            return true;
        } else
            return false;
    }

    private void Highlight() {
        _spriteRenderer.color = Color.green;
    }

    private void UnHighlight() {
        _spriteRenderer.color = Color.white;
    }

    private void OnMouseDown () {
        StateContext context = new StateContext(this, StateMark.Figure);
        GameManager.GM.HandleActionByState(context);
    }
    
}
