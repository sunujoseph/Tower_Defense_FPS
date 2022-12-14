using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
	public static int enemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 30f;
	private float countdown = 2f;

	public float startPeriod = 60.0f; 

	public Text waveCountdownText;


	

	private int waveIndex = 0;

    private void Start()
    {
		countdown = startPeriod;
    }

    void Update()
	{
		if (enemiesAlive > 0)
        {
			return;
        }

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave()
	{

		Wave wave = waves[waveIndex];

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}


		waveIndex++;

		if (waveIndex == waves.Length)
		{
			SceneManager.LoadScene(4);
			this.enabled = false;
		}

	}

	void SpawnEnemy(GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		enemiesAlive++;
	}
}
