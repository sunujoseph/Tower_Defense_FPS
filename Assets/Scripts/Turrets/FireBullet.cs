using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    private Transform target;
    public bool hit = false;
    [SerializeField] GameObject explosion;
    public float speed = 70;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        explosion.transform.position = target.position;
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {

            hitTarget();
            return;
        }
        if (hit != true)
        {
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.Rotate(dir.normalized * Time.deltaTime, Space.World);
        }

    }
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void hitTarget()
    {
        hit = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Instantiate(explosion);
        Destroy(gameObject, 0.6f);

        return;
    }
}
