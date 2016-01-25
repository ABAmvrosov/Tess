using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public int width = 10;
	public int height = 10;
	public Sprite blackTile;
	public Sprite whiteTile;
	public Sprite wallTile;
	public Cell cell;

	private Transform board;

	// Use this for initialization
	void Awake () {
		for (int x = -width/2; x < width/2; x++) {
			for (int y = -height/2; y < height/2; y++) {
				if (y < 0) {
					Cell tile = Instantiate(cell, new Vector3(x,y,0f), Quaternion.identity) as Cell;
					tile.GetComponent<SpriteRenderer>().sprite = blackTile;
					tile.transform.SetParent(this.transform);
				} else {
					Cell tile = Instantiate(cell, new Vector3(x,y,0f), Quaternion.identity) as Cell;
					tile.GetComponent<SpriteRenderer>().sprite = whiteTile;
					tile.transform.SetParent(this.transform);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
