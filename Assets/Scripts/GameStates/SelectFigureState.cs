using UnityEngine;
using System.Collections;

internal class SelectFigureState : State {

    public SelectFigureState() {
        notifierText = "Select figure!";
    }
    protected override void ChangeState(StateContext context) {
        switch (context.stateMark) {
            case StateMark.Figure:
                Figure figure = (Figure) context.contextObject;
                if (figure.CanMove) {
                    GameManager.TheFigureManager.SelectedFigure = figure;
                    GameManager.TheBoardController.HighlightPossibleMoves(figure);
                    GameManager.GM.GameState = new MoveFigureState();
                    StateChanged();
                }
                break;
        }
    }
}
