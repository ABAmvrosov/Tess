public abstract class MoveModel {
	public bool IsFixedMoveModel { get; protected set; }
	public abstract int[,] GetModel (bool bonusMoves);
}
