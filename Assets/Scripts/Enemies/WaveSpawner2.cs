using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static WaveSpawner2;

public class WaveSpawner2 : MonoBehaviour
{
    
    public enum SpawnState { SPAWNING, WAITING, COUNTING };



    [System.Serializable]
    public class Wave2
    {
        public string name;
        public Enemy2[] enemies;
    }

    [System.Serializable]
    public class Enemy2
    {
        public Transform enemyTransform;
        public int count;
        public float rate;
    }



    public Wave2[] waves;
    public Transform spawnPoint;

    public float startPeriod = 10.0f;

    public float timeBetweenWaves = 5.0f;
    private float countdown = 2f;
    
    private int nextWave = 0;

    float searchTimer = 1f;

   public Text waveCountdownText;

    public GameManager gameManager; 


    private SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        countdown = startPeriod;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                BeginNewRound();
            }
            else
            {
                return;
            }
        }

      




        if (countdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));

            }

        }
        else
        {
            countdown -= Time.deltaTime;

            
        }



        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave(Wave2 _wave)
    {
        Debug.Log("spawning wave" + _wave.name);
        state = SpawnState.SPAWNING;


        for (int i = 0; i < _wave.enemies.Length; i++)
        {
            var temp = _wave.enemies[i];
            for(int j = 0; j < temp.count; j++)
            {
                SpawnEnemy(temp.enemyTransform);
                yield return new WaitForSeconds(1f / temp.rate);
            }
           
        }

        state = SpawnState.WAITING;



        yield break;

    }

    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
        
    }

    void BeginNewRound()
    {
        Debug.Log("wave completed");

        state = SpawnState.COUNTING;
        countdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            gameManager.WinGame();
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchTimer -= Time.deltaTime;
        if (searchTimer <= 0f)
        {
            searchTimer = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }


}


