using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public int health = 30;

    private Transform target;

    private int wavepointIndex = 0;



    private void Start()
    {
        target = Waypoint.points[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoints();
        }
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
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
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
