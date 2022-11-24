using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Speed = 8;
    [SerializeField] Transform trans;
    Rigidbody2D body;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            trans.position += transform.forward * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            trans.position -= transform.right * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            trans.position += transform.right * Time.deltaTime * Speed;
        }
             if (Input.GetKey(KeyCode.S))
        {
            trans.position -= transform.forward * Time.deltaTime * Speed;
        }
        
    }
}
