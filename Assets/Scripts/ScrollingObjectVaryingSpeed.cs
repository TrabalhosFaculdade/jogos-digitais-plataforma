using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjectVaryingSpeed : ScrollingObject {

	//valor a ser usado para definir range em relacao 
	//a velocidade de scroll do GameController
	public float rangeFromGameController = 4f;

	protected override float getScrollingSpeed () 
	{
		float minScrollSpeed = GameController.instance.scrollSpeed - rangeFromGameController;
		float maxScrollSpeed = GameController.instance.scrollSpeed + rangeFromGameController;

		return Random.Range (minScrollSpeed, maxScrollSpeed);
	}

}
