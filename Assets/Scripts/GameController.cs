using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public bool gameOver = false;               
	public float scrollSpeed = -4f;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

	void Update()
	{
		//fim de jogo e alguma tecla pressioanda
		//resetando cena
		if (gameOver && Input.GetKeyDown(KeyCode.Space)) 
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		
	}

	public void PlayerDied()
	{
		gameOver = true;
	}
}
