using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float ogSpeed = 5f;
    public float rotateSpeed= 10f;
    float speed;

    public float startHealth = 30;
    float health;

    public GameObject player; 
    private Transform target;

    private int wavepointIndex = 0;

    public Slider healthBar;

    Quaternion enemyRotation;

    private void Start()
    {
        target = Waypoint.points[0];
        speed = ogSpeed;
        health = startHealth;

        player = GameObject.FindWithTag("Player");

        healthBar.value = startHealth;
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
      
       

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoints();
        }

        Vector3 lookDir = Waypoint.points[wavepointIndex].position - transform.position ;
         transform.rotation = Quaternion.LookRotation(lookDir);

        
    }

    void GetNextWaypoints()
    {


        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];



    }

    void EndPath()
    {
        PlayerStat.health--;
        WaveSpawner.enemiesAlive--; 
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health/startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }

}
