using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float SpinSpeed = 0;
    public GameObject orb;
    public float flipspeed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


            orb.transform.Rotate(SpinSpeed * Time.deltaTime, SpinSpeed * Time.deltaTime, SpinSpeed * Time.deltaTime);


        
            

    }
}
