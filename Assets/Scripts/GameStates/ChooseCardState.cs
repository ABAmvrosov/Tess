using UnityEngine;
using System.Collections;

internal class ChooseCardState : State {
    protected override void ChangeState(StateContext context) {
        switch (context.stateMark) {
            case StateMark.MoveCard:
                MovementCard card = (MovementCard) context.contextObject;
                GameManager.TheFigureManager.ActivateFigures(card);
                GameManager.GM.GameState = new SelectFigureState();
                StateChanged();
                break;
        }
    }
}
