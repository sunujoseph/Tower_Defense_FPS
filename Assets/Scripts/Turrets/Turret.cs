using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    public float range = 15f; 
    [SerializeField] GameObject bulletPrefab; 
    public float fireRate = 1;
    private float firecountdown = 0;
    
    [SerializeField] Transform RotatePoint;

    public Transform firepoint;

    
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        audioSource = GetComponent<AudioSource>();

    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        RotatePoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (firecountdown <= 0f)
        {
            Shoot();
            //PlayShootingSound();
            firecountdown = 1f / fireRate;
        }
        firecountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target); 
        }
    }

    private void OnDrawGizmosSeleted ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void PlayShootingSound()
    {
        
        audioSource.Play();
    }
    
}
