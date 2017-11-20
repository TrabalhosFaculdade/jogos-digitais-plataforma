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

	void Update ()
	{
		if (GameController.instance.gameOver)
			rb.velocity = Vector2.zero;
	}

	protected virtual float getScrollingSpeed () 
	{		
		return GameController.instance.scrollSpeed; 
	}
}
