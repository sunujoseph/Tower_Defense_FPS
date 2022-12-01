using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ExplosionDestroy : MonoBehaviour
{
    // Start is called before the first frame update

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
