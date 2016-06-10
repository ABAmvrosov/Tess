using UnityEngine;
using System.Collections;

internal class ChooseCardState : State {

    public ChooseCardState() {
        notifierText = "Choose card!";
    }

    protected override void ChangeState(StateContext context) {
        switch (context.stateMark) {
            case StateMark.MoveCard: 
                GameManager.TheFigureManager.ActivateFigures();
                GameManager.GM.GameState = new SelectFigureState();
                StateChanged();
                break;
            case StateMark.GroundCard:
                GameManager.GM.GameState = new PlaceGroundState();
                StateChanged();
                break;
        }
    }
}
