﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner2 : MonoBehaviour
{

	public Wave[] waves;
	public Enemy enemy;

	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;
    public Transform positionOfSpawn;

	private void Start()
	{
		NextWave();
	}

	private void Update()
	{
		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
		{
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, positionOfSpawn.position, Quaternion.identity) as Enemy;
			spawnedEnemy.OnDeath += OnEnemyDeath;
		}
	}

	void OnEnemyDeath()
	{
		enemiesRemainingAlive--;

		if (enemiesRemainingAlive == 0)
		{
			NextWave();
		}
	}

	void NextWave()
	{
		currentWaveNumber++;
		if (currentWaveNumber - 1 < waves.Length)
		{
			currentWave = waves[currentWaveNumber - 1];

			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}

	}

	[System.Serializable]
	public class Wave
	{
		public int enemyCount;
		public float timeBetweenSpawns;

	}
}
