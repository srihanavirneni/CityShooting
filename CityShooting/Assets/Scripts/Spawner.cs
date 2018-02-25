using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;

    int enemiesRemainingToSpawn2;
    int enemiesRemainingAlive;
    float nextSpawnTime;
    public Transform PositionOfSpawn;

    public LevelManager levelManager;

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        if (enemiesRemainingToSpawn2 > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn2--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, PositionOfSpawn.position, Quaternion.identity) as Enemy;
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

			enemiesRemainingToSpawn2 = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn2;
        }

        if (enemiesRemainingToSpawn2 == 0)
        {
            levelManager.WinLevel();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    [System.Serializable]
	public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;

    }
}
