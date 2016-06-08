public class StateContext {
    public object contextObject { get; set; }
    public StateMark stateMark { get; set; }
    public StateContext(object context, StateMark stateMark) {
        this.contextObject = context;
        this.stateMark = stateMark;
    }
}
