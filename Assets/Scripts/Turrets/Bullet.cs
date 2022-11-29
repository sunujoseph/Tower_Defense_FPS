using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public bool hit = false;
    public float speed = 70;


    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
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
        Destroy(gameObject,0.6f);
        
        return ;
    }

}
