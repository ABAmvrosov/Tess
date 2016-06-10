using UnityEngine;

public class Card : MonoBehaviour {

    protected SpriteRenderer _spriteRenderer;
    protected bool IsMouseOver {
        get {
            return _isMouseOver;
        }
        set {
            _isMouseOver = value;
            if (value)
                Highlight();
            else
                UnHighlight();
        }
    }
    protected bool _isMouseOver = false;

    void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver() {
        if (!IsMouseOver)
            IsMouseOver = true;
    }

    void OnMouseExit() {
        IsMouseOver = false;
    }

    protected virtual void Highlight() {
        _spriteRenderer.color = Color.green;
    }


    protected virtual void UnHighlight() {
        _spriteRenderer.color = Color.white;
    }

    void OnMouseDown () {
        GameManager.TheCardManager.ActiveCard = this;
        ActivateCard ();
	}

	protected virtual void ActivateCard () {
		Debug.LogError ("Should be used on subclasses");	
	}
}
