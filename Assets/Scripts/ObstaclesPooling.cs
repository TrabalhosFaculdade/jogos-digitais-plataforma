using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPooling : MonoBehaviour {

	//tempo de spawn para o proximo item/barril/inimigo
	public float spawnRateMax = 5f;
	public float spawnRateMin = 1.5f;

	public float minYAirEnemy = -2f;
	public float maxYAirEnemy = 2f;

	//prefab de coisas a serem spawnadas
	public GameObject[] barrielsPrefab;
	public GameObject[] airEnemiesPrefab;
	public GameObject[] itemsPrefab;

	private GameObject[] barriels;
	private GameObject[] airEnemies;
	private GameObject[] items;

	private float timeSinceLastSpawned;
	private float spawnX = 10f;
	private float spawnYBarriel = -3.7f;
	private float timeForNextSpawn;

	//tipo de coisas que podem ser criadas
	private enum TipoOBjeto {InimigoAr, Obstaculo, Item}

	void Update () 
	{
		timeSinceLastSpawned += Time.deltaTime;
		if (timeSinceLastSpawned >= timeForNextSpawn) 
		{
			//decide tipo de objeto a ser spawnado
			TipoOBjeto proximo = whatIsNext();
			if (proximo == TipoOBjeto.Obstaculo) {

				int whatPosition = Random.Range (0, barrielsPrefab.Length - 1);

				Vector2 position = new Vector2 (spawnX, spawnYBarriel);
				Instantiate(barrielsPrefab[whatPosition], position, Quaternion.identity);

			} else if (proximo == TipoOBjeto.InimigoAr) {

				int whatPosition = Random.Range (0, airEnemiesPrefab.Length - 1);

				float yInitial = Random.Range (minYAirEnemy, maxYAirEnemy);
				Vector2 position = new Vector2 (spawnX, yInitial);
				Instantiate(airEnemiesPrefab[whatPosition], position, Quaternion.identity);

			} else {
				//TODO spawnar itens aqui
			}
		
			NextTime ();

		}

	}

	void NextTime() 
	{
		timeForNextSpawn = Random.Range (spawnRateMin, spawnRateMax);
		timeSinceLastSpawned = 0;
	}

	TipoOBjeto whatIsNext () 
	{
		int index = Random.Range (0, 2);
		if (index == 0)
			return TipoOBjeto.Obstaculo;
		else if (index == 1)
			return TipoOBjeto.InimigoAr;
		else
			return TipoOBjeto.Item;
	}
	
}
