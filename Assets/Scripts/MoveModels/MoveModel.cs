public abstract class MoveModel {
	public bool IsFixed { get; protected set; }
	public abstract int[,] GetModel (bool bonusMoves);
}
