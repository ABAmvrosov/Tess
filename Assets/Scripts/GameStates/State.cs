using UnityEngine;

public abstract class State {
    public string notifierText;

    public virtual void HandleAction(StateContext context) {
        ChangeState(context);
        Messenger.Broadcast("StateChanged");
    }
    protected abstract void ChangeState (StateContext context);
    protected virtual void StateChanged() {
        Debug.Log("State changed from " + this.GetType() + " to " + GameManager.GM.GameState.GetType());
    }
}
