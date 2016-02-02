using UnityEngine;
using System.Collections;

public class MoveCard : MonoBehaviour {

	public FigureTypes[] figureTypes;
//	public SideType[] sideTypes;
	public int numberOfOwnFigures;
	public int numberOfEnemyFigures;

	[HideInInspector]
	public int counter = 0;
	bool _isTaken;

	void Start () {
		EventManager.OnFigureMove += IncCounter;
		EventManager.OnCardDone += ResetCounter;
	}

	void Update () {
		// If player do all available action from card? Then destroy it.
		if (_isTaken && counter == figureTypes.Length) {
			EventManager.OnCardDone();
			Destroy(gameObject);
			Debug.Log("Destroy");
		}

	}

	void OnMouseDown () {
		if (figureTypes.Length != (numberOfOwnFigures + numberOfEnemyFigures)) {
			Debug.Log ("Fail pick");
			return;
		}
		_isTaken = true;
		Debug.Log ("Card taken card");
		GetComponent<SpriteRenderer> ().color = Color.green;
		Figure[] figures = FindObjectsOfType (typeof(Figure)) as Figure[];
		foreach (Figure figure in figures) 
		{
			if (numberOfEnemyFigures > 0) {
				for (int i = 0; i < figureTypes.Length; i++) {
					if (figure.figureType == figureTypes[i]) {
						figure.GetComponent<BoxCollider2D>().enabled = true;
					}
				}
			} else {
				for (int i = 0; i < figureTypes.Length; i++) {
					if (figure.figureType == figureTypes[i] && figure.side == GameManager.gm.activeSide) {
						figure.GetComponent<BoxCollider2D>().enabled = true;
					}
				}
			}

		}
	}

	void IncCounter () { counter++; }

	void ResetCounter () {
		counter = 0;
	}
}
