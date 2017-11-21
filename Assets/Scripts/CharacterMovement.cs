using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public float speed;
	public float jumpForce;
	private Rigidbody2D rb;

	private bool isGrounded, hasDoubleJump;

	private Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator> ();
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

		UpdateAnimatiom ();

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

	//setting values used by animator
	private void UpdateAnimatiom () 
	{
		anim.SetBool ("IsDead", GameController.instance.gameOver);
		anim.SetBool ("IsGrounded", isGrounded);
	}
}
