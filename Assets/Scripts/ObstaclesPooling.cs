using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPooling : MonoBehaviour {

	//tempo de spawn para o proximo item/barril/inimigo
	public float spawnRateMax = 5f;
	public float spawnRateMin = 1.5f;

	public float minYAirEnemy = -2f;
	public float maxYAirEnemy = 2f;

	public float minYItem = -3.5f;
	public float maxYItem = 2f;

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

				int whatIndex = Random.Range (0, barrielsPrefab.Length);

				Vector2 position = new Vector2 (spawnX, spawnYBarriel);
				Instantiate(barrielsPrefab[whatIndex], position, Quaternion.identity);

			} else if (proximo == TipoOBjeto.InimigoAr) {

				int whatIndex = Random.Range (0, airEnemiesPrefab.Length);

				float yInitial = Random.Range (minYAirEnemy, maxYAirEnemy);
				Vector2 position = new Vector2 (spawnX, yInitial);
				Instantiate(airEnemiesPrefab[whatIndex], position, Quaternion.identity);

			} else {

				int whatIndex = Random.Range (0, itemsPrefab.Length);

				float yInitial = Random.Range (minYItem, maxYItem);
				Vector2 position = new Vector2 (spawnX, yInitial);
				Instantiate(itemsPrefab[whatIndex], position, Quaternion.identity);

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
		int index = Random.Range (0, 3);
		if (index == 0) 
			return TipoOBjeto.Obstaculo;

		if (index == 1) 
			return TipoOBjeto.InimigoAr;
		
		return TipoOBjeto.Item;
	}
	
}
