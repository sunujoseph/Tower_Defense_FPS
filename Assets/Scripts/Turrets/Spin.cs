using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float SpinSpeed = 0;
    public GameObject Parent;
    public Transform rotato;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotato.transform.Rotate (Parent.transform.rotation.x, 0, SpinSpeed * Time.deltaTime);
    }
}
