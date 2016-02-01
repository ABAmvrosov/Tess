using UnityEngine;
using System.Collections;

public class MoveCard : MonoBehaviour {

	public FigureTypes[] figureTypes;
	public SideType[] sideTypes;

	public int counter = 0;
	bool _isTaken;

	void Start () {
		EventManager.OnFigureMove += IncCounter;
		EventManager.OnCardDone += ResetCounter;
	}

	void Update () {
		if (_isTaken && counter == figureTypes.Length) { //&& some counter)
			EventManager.OnCardDone();
			Destroy(gameObject);
			Debug.Log("Destroy");
		}
	}

	void OnMouseDown () {
		if (figureTypes.Length != sideTypes.Length) {
			return;
		}
		_isTaken = true;
		GetComponent<SpriteRenderer> ().color = Color.green;
		Figure[] figures = FindObjectsOfType (typeof(Figure)) as Figure[];
		foreach (Figure figure in figures) 
		{
			for (int i = 0; i < figureTypes.Length; i++) {
				if (figure.figureType == figureTypes[i] && figure.side == sideTypes[i]) {
					figure.GetComponent<BoxCollider2D>().enabled = true;
				}
			}
		}
	}

	void IncCounter () { counter++; }

	void ResetCounter () {
		counter = 0;
	}
}
