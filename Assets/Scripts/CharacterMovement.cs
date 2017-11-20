using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public float speed;
	public float jumpForce;
	private Rigidbody2D rb;

	private bool isGrounded, hasDoubleJump;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		isGrounded = true;
		hasDoubleJump = true;
	}

	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (isGrounded || hasDoubleJump) 
			{
				rb.AddForce (new Vector2 (0, jumpForce));
				if (hasDoubleJump && !isGrounded)
					hasDoubleJump = false;
			}

		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Floor") 
		{
			isGrounded = true;
			hasDoubleJump = true;
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.tag == "Floor") 
			isGrounded = false;
	}
}
