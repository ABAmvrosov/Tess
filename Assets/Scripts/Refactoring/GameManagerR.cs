using UnityEngine;
using System.Collections;

public class GameManagerR : MonoBehaviour {
	public static GameManagerR gm;
	public Board board;
	public GameResources resourses;
	void Awake () {
		if (gm == null)
			gm = this.GetComponent<GameManagerR> ();
		if (resourses == null)
			resourses = this.GetComponent<GameResources> ();
	}
}
