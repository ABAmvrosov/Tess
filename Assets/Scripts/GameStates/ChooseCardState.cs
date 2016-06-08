using UnityEngine;
using System.Collections;

internal class ChooseCardState : State {
    protected override void ChangeState(StateContext context) {
        switch (context.stateMark) {
            case StateMark.MoveCard: 
                GameManager.TheFigureManager.ActivateFigures();
                GameManager.GM.GameState = new SelectFigureState();
                StateChanged();
                break;
        }
    }
}
