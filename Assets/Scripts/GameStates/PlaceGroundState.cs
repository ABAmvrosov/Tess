using UnityEngine;
using System.Collections;

internal class PlaceGroundState : State {

    public PlaceGroundState() {
        notifierText = "Place ground!";
    }

    protected override void ChangeState(StateContext context) {
        switch (context.stateMark) {
            case StateMark.Tile:
                GameManager.TheBoardController.PlaceGround((Tile)context.contextObject);
                GameManager.GM.GameState = new ChooseCardState();
                break;
        }
    }
}
