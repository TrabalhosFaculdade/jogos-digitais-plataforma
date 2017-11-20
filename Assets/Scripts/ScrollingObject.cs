using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (getScrollingSpeed(), 0);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Destroy (this.gameObject);
	}

	protected virtual float getScrollingSpeed () 
	{
		return GameController.instance.scrollSpeed; 
	}
}
