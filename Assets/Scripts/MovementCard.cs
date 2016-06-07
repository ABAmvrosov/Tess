using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MovementCard : Card {
	public List<Type> AbleTypes { get; set; }
	public int NumberOfMoves { get; set; }

	protected override void ActivateCard() {
		GameManager.TheFigureManager.ActivateFigures (this);
	}
}
