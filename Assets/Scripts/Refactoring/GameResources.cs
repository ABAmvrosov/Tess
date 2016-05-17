using UnityEngine;
using System.Collections;

public class GameResources : MonoBehaviour {

	private Sprite _black;
	private Sprite _white;
	private Sprite _wall;

	void Awake() {
		LoadResoursers ();
	}

	void LoadResoursers() {
		_black = Resources.Load<Sprite> ("Sprites/Black");
		_white = Resources.Load<Sprite> ("Sprites/White");
		_wall = Resources.Load<Sprite> ("Sprites/Wall");
	}
	public Sprite GetTileImage(TileType tileType) {
		switch (tileType) {
		case TileType.Black:
			return _black;
		case TileType.White:
			return _white;
		case TileType.Wall:
			return _wall;
		default:
			return null;		
		}
	}
}
