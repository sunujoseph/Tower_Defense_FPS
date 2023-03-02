using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ExplosionDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    void Start()
    {
        
        Destroy(this.gameObject, GetComponent<ParticleSystem>().main.duration);
        
    }

    private void Awake()
    {
        Destroy(this.gameObject, GetComponent<ParticleSystem>().main.duration);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
