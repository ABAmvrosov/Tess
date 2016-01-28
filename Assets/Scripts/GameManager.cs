using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	public BoardManager board;
	public Figure figureForMoveHandler;

	void Awake () {
		if (gm == null)
			gm = this.GetComponent<GameManager> ();
		if (board == null)
			board = GameObject.FindGameObjectWithTag ("Board").GetComponent<BoardManager> ();
	}
}
