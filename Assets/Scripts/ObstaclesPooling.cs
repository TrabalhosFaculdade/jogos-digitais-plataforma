using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPooling : MonoBehaviour {

	public int columnPoolSize = 5;
	public GameObject[] columnPrefab;
	public float spawnRateMax = 5f;
	public float spawnRateMin = 1.5f;

	private GameObject[] columns;
	private Vector2 objectPoolPosition = new Vector2(-15f,-25f);
	private float timeSinceLastSpawned;
	private float spawnX = 10f;
	private float spawnY = -3.7f;
	private float nextSpawn;
	private int currentColumn = 0;

	void Start () 
	{
		columns = new GameObject[columnPoolSize];
		for (int i = 0; i < columnPoolSize; i++) 
		{
			int indexPrefab = Random.Range (0, columnPrefab.Length - 1);
			columns [i] = (GameObject)Instantiate(columnPrefab[indexPrefab], objectPoolPosition, Quaternion.identity);
		}

	}

	void Update () 
	{
		timeSinceLastSpawned += Time.deltaTime;
		if (timeSinceLastSpawned >= nextSpawn) 
		{
			columns [currentColumn].transform.position = new Vector2 (spawnX, spawnY);
			currentColumn++;
			if (currentColumn >= columnPoolSize) 
				currentColumn = 0;
		
			NextTime ();

		}

	}

	void NextTime() 
	{
		nextSpawn = Random.Range (spawnRateMin, spawnRateMax);
		timeSinceLastSpawned = 0;
	}
}
