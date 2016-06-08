using UnityEngine;

internal abstract class State {
    internal virtual void HandleAction(StateContext context) {
        ChangeState(context);
    }
    protected abstract void ChangeState (StateContext context);
    protected virtual void StateChanged() {
        Debug.Log("State changed from " + this.GetType() + " to " + GameManager.GM.GameState.GetType());
    }
}
