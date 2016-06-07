using UnityEngine;
using System.Collections;

public class TileFactory : MonoBehaviour {

	[SerializeField] private Tile tilePrefab;

	public Tile GetWallTile(int rowIndex, int colIndex) {
		Tile tile = Instantiate (tilePrefab);
		tile.Type = TileType.Wall;
		tile.transform.position = new Vector3 (rowIndex, colIndex,  0.1f);
		tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Sprites/Wall");
		return tile;
	}

	public Tile GetWhiteTile(int rowIndex, int colIndex) {
		Tile tile = Instantiate (tilePrefab);
		tile.Type = TileType.White;
		tile.transform.position = new Vector3 (rowIndex, colIndex, 0.1f);
		tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Sprites/White");
		return tile;
	}

	public Tile GetBlackTile (int rowIndex, int colIndex) {
		Tile tile = Instantiate (tilePrefab);
		tile.Type = TileType.Black;
		tile.transform.position = new Vector3 (rowIndex, colIndex,  0.1f);
		tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Sprites/Black");
		return tile;
	}

	public void SetTileType (Tile tile, TileType tileType) {
		tile.Type = tileType;
		switch (tileType) {
		case TileType.Wall:
			tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Sprites/Wall");	
			break;
		case TileType.White:
			tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Sprites/White");
			break;
		case TileType.Black:
			tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Sprites/Black");
			break;
		}		
	}
}
