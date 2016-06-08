using UnityEngine;
using System.Collections;

internal class MoveFigureState : State {
    protected override void ChangeState(StateContext context) {
        switch (context.stateMark) {
            case StateMark.Figure:
                Figure figure = (Figure) context.contextObject;
                Tile attackedTile = GameManager.TheBoardController.GetTile(figure.horCoordinateX, figure.verCoordinateY);
                GameManager.TheFigureManager.Move(attackedTile);
                DetermineNextState();
                break;
            case StateMark.MoveToTile:
                Tile destination = (Tile) context.contextObject;
                if (destination.PossibleMove) {
                    GameManager.TheFigureManager.Move(destination);
                    DetermineNextState();
                }
                break;
        }
    }

    private void DetermineNextState() {
        if (CanMoveAgain()) {
            GameManager.GM.GameState = new SelectFigureState();
        }
        else {
            GameManager.GM.GameState = new ChooseCardState();
        }
        StateChanged();
    }

    private bool CanMoveAgain() {
        MovementCard card = (MovementCard)GameManager.TheCardManager.ActiveCard;
        return card.NumberOfMoves > 0;
    }
}
