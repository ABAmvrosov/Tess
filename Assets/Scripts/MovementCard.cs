using UnityEngine;
using System.Collections.Generic;

public class MovementCard : Card {
	public List<FigureType> AbleTypes {
        get { return _ableTypes; }
        set { _ableTypes = value; }
    }
    [SerializeField] private List<FigureType> _ableTypes;

	public int NumberOfMoves {
        get { return _remainingNumberOfMoves; }
        set { _remainingNumberOfMoves = value; }
    }
    private int _remainingNumberOfMoves;
    [SerializeField] private int _numberOfMoves;

    void Start() {
        ResetNumberOfMoves();
        Messenger.AddListener("NextTurn", ResetNumberOfMoves);
    }

	protected override void ActivateCard() {
        StateContext context = new StateContext(this, StateMark.MoveCard);
        GameManager.GM.HandleActionByState(context);
	}

    void ResetNumberOfMoves() {
        _remainingNumberOfMoves = _numberOfMoves;
    }
}
