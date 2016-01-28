using UnityEngine;
using System.Collections;
using System;

public class EventManager : MonoBehaviour {

	public delegate void ClickAction();
	public static event ClickAction OnClicked;

	public delegate void MoveAction();
	public static event MoveAction OnMove;
//	public static Action OnMove;

}
