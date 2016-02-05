using UnityEngine;
using System.Collections;

public class CardsManager : MonoBehaviour {

	public GameObject[] cardPrefabs;
	public Transform _firstCardPos;
	GameObject[] _cards;
	Vector3 horOffset = new Vector3(2f, 0f, 0f);
	Vector3 verOffset = new Vector3(0f, 1.5f, 0f);

	void Start () {
		_cards = new GameObject[cardPrefabs.Length];
		Vector3 position = _firstCardPos.position;
		for (int i = 0; i < cardPrefabs.Length; i++) {
			_cards[i] = Instantiate(cardPrefabs[i], position, Quaternion.identity) as GameObject;
			_cards[i].transform.parent = gameObject.transform;
			position += horOffset;
			if ((i + 1) % 3 == 0 && i != 0) {
				position -= verOffset;
				position.x = _firstCardPos.position.x;
			}
		}
	}

	public void RefreshCards () {
		_cards = new GameObject[cardPrefabs.Length];
		Vector3 position = _firstCardPos.position;
		for (int i = 0; i < cardPrefabs.Length; i++) {
			_cards[i] = Instantiate(cardPrefabs[i], position, Quaternion.identity) as GameObject;
			_cards[i].transform.parent = gameObject.transform;
			position += horOffset;
			if ((i + 1) % 3 == 0 && i != 0) {
				position -= verOffset;
				position.x = _firstCardPos.position.x;
			}
		}
	}
}
