using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MovementCard : Card {
	public List<FigureType> AbleTypes {
        get { return _ableTypes; }
        set { _ableTypes = value; }
    }
    [SerializeField] private List<FigureType> _ableTypes;
	public int NumberOfMoves {
        get { return _numberOfMoves; }
        set { _numberOfMoves = value; }
    }
    [SerializeField] private int _numberOfMoves;

	protected override void ActivateCard() {
        GameManager.TheCardManager.ActiveCard = this;
        StateContext context = new StateContext(this, StateMark.MoveCard);
        GameManager.GM.HandleActionByState(context);
	}
}
