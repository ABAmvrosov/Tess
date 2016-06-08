using UnityEngine;
using System.Collections;

public class Figure : MonoBehaviour {

	public Side FigureSide { get; set; }
    public FigureType Type { get; set; }
	public MoveModel MovementModel { get; set; }
	public bool CanMove { 
		get { return _canMove; } 
		set { _canMove = value; }
    }
    private bool _canMove = false;
    public int horCoordinateX {
		get;
		private set;
	}
	public int verCoordinateY {
		get;
		private set;
    }

    void OnEnable() {
		Messenger.AddListener ("NextTurn", UpdatePosition);
	}

	void OnMouseDown () {
        StateContext context = new StateContext(this, StateMark.Figure);
        GameManager.GM.HandleActionByState(context);
    }

	void OnDisable () {
		Messenger.RemoveListener ("NextTurn", UpdatePosition);
		Messenger<GameObject>.Broadcast ("KillFigure", this.gameObject);
	}

	public bool IsEnemy () {
		if (FigureSide != GameManager.GM.CurrentPlayer) {
			return true;
		} else
			return false;
	}

	protected void UpdatePosition () {
		horCoordinateX = (int) this.transform.position.x;
		verCoordinateY = (int) this.transform.position.y;
	}
}
