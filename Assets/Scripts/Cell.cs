using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	private TileTypes _tileType; 
	private SpriteRenderer _spriteRenderer;	
	private Sprite _cellType;

	void Awake() {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		switch (_spriteRenderer.sprite.name) 
		{
			case "White":
				_tileType = TileTypes.White;
				break;
			case "black":
				_tileType = TileTypes.Black;
				break;
			case "Wall":
				_tileType = TileTypes.Wall;
				break;
		}
	}
		
	void OnMouseEnter() {
		Debug.Log ("I am over " + _tileType);
		_spriteRenderer.color = Color.green;

	}

	void OnMouseOver() {
		_spriteRenderer.color = Color.green;
	}

	void OnMouseExit() {
		_spriteRenderer.color = Color.white;
	}
}
