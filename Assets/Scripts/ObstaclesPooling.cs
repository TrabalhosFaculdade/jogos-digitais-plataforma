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

	public int maxNumberBarriels = 4;
	public int maxNumberFlyingEnemies = 2;
	public int maxNumberItems = 1;

	private int currentNumberBarriels = 0;
	private int currentNumberFlyingEnemies = 0;
	private int currentNumberItems = 0;


	//prefab de coisas a serem spawnadas
	public GameObject[] barrielsPrefab;
	public GameObject[] airEnemiesPrefab;
	public GameObject[] itemsPrefab;

	private GameObject[] barriels;
	private GameObject[] airEnemies;
	private GameObject[] items;

	private float timeSinceLastSpawned;
	private float spawnX = 10f;
	private float spawnYBarriel = -3.93f;
	private float timeForNextSpawn;

	//tipo de coisas que podem ser criadas
	private enum TipoOBjeto {InimigoAr, Obstaculo, Item}

	void Update () 
	{
		timeSinceLastSpawned += Time.deltaTime;
		if (GameController.instance.gameOver == false && timeSinceLastSpawned >= timeForNextSpawn) 
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
		int index = Random.Range(0,101);

		//se todos puderem ser usados
		if (currentNumberBarriels < maxNumberBarriels &&
		    currentNumberFlyingEnemies < maxNumberFlyingEnemies &&
		    currentNumberItems < maxNumberItems) 
		{
			//50% de ser barril
			//30% de ser obstaculo voador
			//20% de ser item
			if (index < 50) 
				return TipoOBjeto.Obstaculo;

			if (index >= 50 && index < 80) 
				return TipoOBjeto.InimigoAr;

			return TipoOBjeto.Item;
		}

		//se nao puder ser barril
		if (currentNumberBarriels >= maxNumberBarriels) 
		{
			//inimigo voador: 60
			//item: 40
			if (index < 60)
				return getInimigoVoadorComoResultado ();
			else
				return getItemComoResultado ();
		}

		//se nao puder ser inimigo voador
		if (currentNumberFlyingEnemies >= maxNumberFlyingEnemies) 
		{
			//barril: 70
			//item: 30
			if (index < 70)
				return getBarrilComoResultado ();
			else
				return getItemComoResultado ();
		}

		//se nao puder ser item
		if (currentNumberItems >= maxNumberItems) 
		{
			//barril: 65
			//inimigo voador: 35
			if (index < 65)
				return getBarrilComoResultado ();
			else
				return getInimigoVoadorComoResultado ();
		}

		throw new System.AccessViolationException ("Código não encontrado. Algo de errado com a lógica");

	}

	private TipoOBjeto getBarrilComoResultado ()
	{
		currentNumberBarriels++;
		currentNumberFlyingEnemies = 0;
		currentNumberItems = 0;
		return TipoOBjeto.Obstaculo;
	}

	private TipoOBjeto getInimigoVoadorComoResultado ()
	{
		currentNumberBarriels = 0;
		currentNumberFlyingEnemies++;
		currentNumberItems = 0;
		return TipoOBjeto.InimigoAr;
	}

	private TipoOBjeto getItemComoResultado ()
	{
		currentNumberBarriels = 0;
		currentNumberFlyingEnemies = 0;
		currentNumberItems++;
		return TipoOBjeto.Item;
	}


}
