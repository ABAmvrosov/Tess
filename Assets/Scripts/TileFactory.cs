using UnityEngine;

public class TileFactory : MonoBehaviour {
    
	[SerializeField] private Tile _white;
	[SerializeField] private Tile _black;
	[SerializeField] private Tile _wall;
    [SerializeField] private GameObject _tileContainer;
    private Sprite _wallSprite;
    private Sprite _whiteSprite;
    private Sprite _blackSprite;

    void Awake() {
        _wallSprite = Resources.Load<Sprite>("Sprites/Wall");
        _whiteSprite = Resources.Load<Sprite>("Sprites/White");
        _blackSprite = Resources.Load<Sprite>("Sprites/Black");
    }

    public Tile GetTile(GameSide tileSide, int horCoordinateX, int verCoordinateY) {
        Tile result = null;
        switch (tileSide) {
            case GameSide.White:
                result = Instantiate(_white);
                break;
            case GameSide.Black:
                result = Instantiate(_black);
                break;
            case GameSide.Neutral:
                result = Instantiate(_wall);
                break;
        }
        ConfigurateTile(result, horCoordinateX, verCoordinateY);
        return result;
    }

    private void ConfigurateTile(Tile tile, int horCoordinateX, int verCoordinateY) {
        tile.transform.position = new Vector3(horCoordinateX, verCoordinateY, 0.1f);
        tile.name = "Tile [" + horCoordinateX + ", " + verCoordinateY + "]";
        tile.transform.SetParent(_tileContainer.transform);
    }

	public void SetTileSide (Tile tile, GameSide tileSide) {
		tile.TileSide = tileSide;
		switch (tileSide) {
		case GameSide.Neutral:
			tile.GetComponent<SpriteRenderer>().sprite = _wallSprite;	
			break;
		case GameSide.White:
			tile.GetComponent<SpriteRenderer>().sprite = _whiteSprite;
			break;
		case GameSide.Black:
			tile.GetComponent<SpriteRenderer>().sprite = _blackSprite;
			break;
		}		
	}
}
