using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour {

	public int scoreWhenCollected = 100;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player")
			GameController.instance.AddToScore (scoreWhenCollected);

		Destroy (this.gameObject);
	}

}
