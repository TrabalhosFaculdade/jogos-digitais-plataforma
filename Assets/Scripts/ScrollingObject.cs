using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (GameController.instance.scrollSpeed, 0);

	}

}
