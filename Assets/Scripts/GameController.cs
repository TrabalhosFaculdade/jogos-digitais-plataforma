using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public bool gameOver = false;               
	public float scrollSpeed = -4f;
	public float speedIncrease = -0.5f;
	public float periodTime = 0.5f;
	public float speedLimit = -15f;

	private float currentTime = 0f;

	private int currentScoreCounter = 0;
	private int limitScoreCounter = 10;

	public Text scoreText;
	public GameObject gameOverText;
	private int score = 0;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

	void Update()
	{
		float timePassed = Time.deltaTime;
		AddTime (timePassed);
		CountTimePassing ();

		//fim de jogo e alguma tecla pressioanda
		//resetando cena
		if (gameOver && Input.anyKey) 
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
		print ("Player Died");
		gameOver = true;
		scrollSpeed = 0f;

		gameOverText.SetActive (true);
	}

	public void AddToScore(int value)
	{
		if (!gameOver) {
			score += value;
			scoreText.text = score.ToString();
		}
	}

	private void CountTimePassing()
	{
		currentScoreCounter++;
		if (currentScoreCounter >= limitScoreCounter) {
			currentScoreCounter = 0;
			AddToScore (1);
		}
	}
}
