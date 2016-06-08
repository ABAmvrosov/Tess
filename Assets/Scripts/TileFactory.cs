using UnityEngine;
using System.Collections;

public class TileFactory : MonoBehaviour {

	[SerializeField] private Tile tilePrefab;
    [SerializeField] private GameObject _tileContainer;

    public Tile GetTile(TileType type, int horCoordinateX, int verCoordinateY) {
        Tile tile = Instantiate(tilePrefab);
        tile.transform.position = new Vector3(horCoordinateX, verCoordinateY, 0.1f);
        tile.name = "Tile [" + horCoordinateX + ", " + verCoordinateY + "]";
        tile.transform.SetParent(_tileContainer.transform);
        switch (type) {
            case TileType.White:
                tile.Type = TileType.White;
                tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/White");
                break;
            case TileType.Black:
                tile.Type = TileType.Black;
                tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Black");
                break;
            case TileType.Wall:
                tile.Type = TileType.Wall;
                tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Wall");
                break;
        }
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
