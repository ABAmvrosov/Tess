using UnityEngine;

public class Card : MonoBehaviour {
	
	void OnMouseDown () {
		ActivateCard ();
	}

	protected virtual void ActivateCard () {
		Debug.LogError ("Should be used on subclasses");	
	}
}
