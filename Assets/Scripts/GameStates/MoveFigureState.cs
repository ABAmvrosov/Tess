using UnityEngine;
using System.Collections;

internal class MoveFigureState : State {

    public MoveFigureState() {
        notifierText = "Move choosed figure!";                
    }

    protected override void ChangeState(StateContext context) {
        switch (context.stateMark) {
            case StateMark.Figure:
                Figure figure = (Figure) context.contextObject;
                Tile destTile = GameManager.TheBoardController.GetTile(figure.Coordinates);
                if (!figure.IsEnemy()) {
                    break;
                }
                GameManager.TheFigureManager.Move(destTile);
                DetermineNextState();
                break;
            case StateMark.Tile:
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
            Messenger.Broadcast("NextTurn");
        }
        StateChanged();
    }

    private bool CanMoveAgain() {
        MovementCard card = (MovementCard)GameManager.TheCardManager.ActiveCard;
        return --card.NumberOfMoves > 0;
    }
}
