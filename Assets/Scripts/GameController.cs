using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public bool gameOver = false;               
	public float scrollSpeed = -4f;
	public float speedIncrease = -0.5f;
	public float periodTime = 0.5f;
	public float currentTime = 0f;
	public float speedLimit = -15f;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

	void Update()
	{
		AddTime (Time.deltaTime);

		//fim de jogo e alguma tecla pressioanda
		//resetando cena
		if (gameOver && Input.GetKeyDown(KeyCode.Space)) 
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		
	}

	void AddTime(float delta)
	{
		currentTime += delta;
		if (currentTime >= periodTime && speedLimit > scrollSpeed) 
		{
			scrollSpeed += speedIncrease;
			currentTime = 0;	
		}
	}

	public void PlayerDied()
	{
		gameOver = true;
	}
}
