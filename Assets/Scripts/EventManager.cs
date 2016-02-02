using UnityEngine;
using System.Collections;
using System;

public static class EventManager {


	public static Action OnCardChoose;

	// 1) private void IncCounter () from MoveCard Class
	public static Action OnFigureMove;

	public static Action OnFigurePick;

	public static Action CancelFigurePicked;

	// 1) private void ResetCounter () from MoveCard Class
	public static Action OnCardDone;

}
