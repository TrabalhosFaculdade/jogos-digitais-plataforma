﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (-3, 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
