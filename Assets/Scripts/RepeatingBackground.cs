using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private float groundHorizontalLength;

	void Awake () 
	{
		//valor a ser usado para mover o background
		groundHorizontalLength = GetComponent<Renderer>().bounds.size.x;
	}

	void Update () 
	{
		if (transform.position.x < -groundHorizontalLength)
			RepositionBackground ();
	}

	private void RepositionBackground()
	{
		//movendo background para compor o restante da imagem
		Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);
		transform.position = (Vector2) transform.position + groundOffSet;
	}

}
